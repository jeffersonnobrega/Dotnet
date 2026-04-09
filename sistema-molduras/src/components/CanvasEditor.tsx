"use client";

import { useState, useRef, useEffect } from "react";
import PhotoUpload from "./PhotoUpload";
import LeadForm from "./LeadForm";
import { supabase } from "@/lib/supabase";
import { CandidatoTheme } from "@/lib/theme-mapper";
import { Download, Share2 } from "lucide-react";

interface CanvasEditorProps {
  candidatoId: string;
  corPrimaria?: string;
  molduraUrl?: string;
  theme: CandidatoTheme["editor"];
}

export default function CanvasEditor({
  candidatoId,
  corPrimaria = "#000000",
  molduraUrl = "/frames/moldura.png",
  theme,
}: CanvasEditorProps) {
  const [selectedFile, setSelectedFile] = useState<File | null>(null);
  const [zoom, setZoom] = useState(1);
  const [offset, setOffset] = useState({ x: 0, y: 0 });
  const [showFrame, setShowFrame] = useState(true);
  const [isProcessing, setIsProcessing] = useState(false);
  const [leadData, setLeadData] = useState<{
    nome: string;
    whatsapp: string;
  } | null>(null);
  const [isDragging, setIsDragging] = useState(false);
  const [lastPos, setLastPos] = useState({ x: 0, y: 0 });

  const canvasRef = useRef<HTMLCanvasElement>(null);

  // Handlers de interação
  const handleStart = (x: number, y: number) => {
    if (!selectedFile) return;
    setIsDragging(true);
    setLastPos({ x, y });
  };
  const handleMove = (x: number, y: number) => {
    if (!isDragging || !selectedFile) return;
    const dx = x - lastPos.x;
    const dy = y - lastPos.y;
    setOffset((prev) => ({ x: prev.x + dx * 2, y: prev.y + dy * 2 }));
    setLastPos({ x, y });
  };
  const handleEnd = () => setIsDragging(false);
  const handleWheel = (e: React.WheelEvent) => {
    if (!selectedFile) return;
    const delta = e.deltaY < 0 ? 0.05 : -0.05;
    setZoom((prev) => Math.min(Math.max(prev + delta, 1), 4));
  };

  const handleLeadSubmit = async (data: { nome: string; whatsapp: string }) => {
    try {
      const { error } = await supabase.from("leads").insert([
        {
          nome: data.nome,
          whatsapp: data.whatsapp,
          candidato_slug: candidatoId,
        },
      ]);
      if (error) throw error;
      setLeadData(data);
      await supabase.rpc("increment_leads_count", {
        slug_candidato: candidatoId,
      });
    } catch (error) {
      console.error(error);
    }
  };

  const handleDownload = async () => {
    if (!canvasRef.current || isProcessing) return;
    setIsProcessing(true);
    try {
      const dataUrl = canvasRef.current.toDataURL("image/png");
      const link = document.createElement("a");
      link.download = `foto-${candidatoId}.png`;
      link.href = dataUrl;
      link.click();
    } finally {
      setIsProcessing(false);
    }
  };

  const shareOnWhatsApp = () => {
    const text = encodeURIComponent(
      `Acabei de criar minha foto oficial! Crie a sua também: ${window.location.href}`,
    );
    window.open(`https://wa.me/?text=${text}`, "_blank");
  };

  // Efeito de renderização do Canvas (Mantido original)
  useEffect(() => {
    if (selectedFile && canvasRef.current) {
      const canvas = canvasRef.current;
      const ctx = canvas.getContext("2d");
      if (!ctx) return;
      const imgUser = new Image();
      const imgFrame = new Image();
      imgUser.crossOrigin = "anonymous";
      imgFrame.crossOrigin = "anonymous";
      let loaded = 0;
      const render = () => {
        loaded++;
        if (loaded === 2) {
          canvas.width = 1080;
          canvas.height = 1920;
          ctx.clearRect(0, 0, canvas.width, canvas.height);
          ctx.save();
          ctx.translate(
            canvas.width / 2 + offset.x,
            canvas.height / 2 + offset.y,
          );
          ctx.scale(zoom, zoom);
          const scale = Math.max(
            canvas.width / imgUser.width,
            canvas.height / imgUser.height,
          );
          ctx.drawImage(
            imgUser,
            -(imgUser.width * scale) / 2,
            -(imgUser.height * scale) / 2,
            imgUser.width * scale,
            imgUser.height * scale,
          );
          ctx.restore();
          if (showFrame)
            ctx.drawImage(imgFrame, 0, 0, canvas.width, canvas.height);
        }
      };
      imgUser.onload = render;
      imgFrame.onload = render;
      const reader = new FileReader();
      reader.onload = (e) => (imgUser.src = e.target?.result as string);
      reader.readAsDataURL(selectedFile);
      imgFrame.src = molduraUrl;
    }
  }, [selectedFile, zoom, offset, showFrame, molduraUrl]);

  return (
    <div className="flex flex-col gap-6 w-full">
      {/* AREA DO CANVAS */}
      <div className="w-full">
        <div
          className={`relative w-full aspect-[9/16] shadow-2xl rounded-[2rem] overflow-hidden border-4 ${theme.canvasBg} touch-none cursor-grab active:cursor-grabbing`}
          style={{ borderColor: theme.canvasBorder }}
          onMouseDown={(e) => handleStart(e.clientX, e.clientY)}
          onMouseMove={(e) => handleMove(e.clientX, e.clientY)}
          onMouseUp={handleEnd}
          onMouseLeave={handleEnd}
          onWheel={handleWheel}
          onTouchStart={(e) =>
            handleStart(e.touches[0].clientX, e.touches[0].clientY)
          }
          onTouchMove={(e) =>
            handleMove(e.touches[0].clientX, e.touches[0].clientY)
          }
          onTouchEnd={handleEnd}
        >
          {selectedFile ? (
            <canvas
              ref={canvasRef}
              className="w-full h-full object-contain pointer-events-none"
            />
          ) : (
            <div className="flex items-center justify-center h-full animate-pulse px-6 text-center">
              <p
                className={`${theme.instructions} text-[10px] font-black uppercase tracking-widest`}
              >
                Clique para adicionar sua foto
              </p>
            </div>
          )}
          {showFrame && (
            <img
              src={molduraUrl}
              alt="Frame"
              className="absolute inset-0 w-full h-full object-contain pointer-events-none z-10"
            />
          )}
          {!selectedFile && (
            <div className="absolute inset-0 z-20 opacity-0 cursor-pointer">
              <PhotoUpload onImageSelect={setSelectedFile} />
            </div>
          )}
        </div>
      </div>

      {/* CONTROLES E FORMULÁRIO */}
      <div className="w-full space-y-4">
        {selectedFile && (
          <div className="animate-in fade-in slide-in-from-bottom-4 duration-500 space-y-4">
            {/* Ajustes de Zoom e Foto */}
            <div
              className={`${theme.containerBg} p-4 rounded-3xl border ${theme.containerBorder} space-y-4`}
            >
              <div className="space-y-2">
                <div className="flex justify-between text-[10px] font-black uppercase">
                  <span className={theme.controls.label}>Ajuste de Zoom</span>
                  <span style={{ color: theme.controls.value }}>
                    {Math.round(zoom * 100)}%
                  </span>
                </div>
                <input
                  type="range"
                  min="1"
                  max="4"
                  step="0.01"
                  value={zoom}
                  onChange={(e) => setZoom(parseFloat(e.target.value))}
                  className="w-full h-2 rounded-lg appearance-none cursor-pointer bg-slate-200"
                  style={{ accentColor: theme.controls.value }}
                />
              </div>
              <div className="grid grid-cols-2 gap-2">
                <button
                  onClick={() => setOffset({ x: 0, y: 0 })}
                  className="py-2 text-[9px] font-bold bg-slate-100 rounded-lg uppercase"
                >
                  Centralizar
                </button>
                <button
                  onClick={() => {
                    setSelectedFile(null);
                    setLeadData(null);
                  }}
                  className="py-2 text-[9px] font-black text-red-500 bg-red-50 rounded-lg uppercase"
                >
                  Trocar Foto
                </button>
              </div>
            </div>

            {/* Ação Final: Formulário ou Download */}
            {!leadData ? (
              <LeadForm onSubmit={handleLeadSubmit} />
            ) : (
              <div className="space-y-3 animate-in zoom-in-95">
                <button
                  onClick={handleDownload}
                  disabled={isProcessing}
                  className="w-full py-4 rounded-2xl font-black uppercase tracking-widest flex items-center justify-center gap-2 shadow-lg transition-all active:scale-95 text-xs"
                  style={{
                    backgroundColor: theme.downloadBtn.bg,
                    color: theme.downloadBtn.text,
                  }}
                >
                  <Download className="w-4 h-4" />
                  {isProcessing ? "Gerando..." : "Baixar Foto Oficial"}
                </button>

                <button
                  onClick={shareOnWhatsApp}
                  className="w-full py-4 rounded-2xl font-black uppercase tracking-widest flex items-center justify-center gap-2 border-2 transition-all active:scale-95 text-xs bg-green-500 text-white border-green-600 shadow-md"
                >
                  <Share2 className="w-4 h-4" />
                  Compartilhar no Zap
                </button>
              </div>
            )}
          </div>
        )}
      </div>
    </div>
  );
}
