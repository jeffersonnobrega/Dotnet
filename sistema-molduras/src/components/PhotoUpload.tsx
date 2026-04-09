// src/components/PhotoUpload.tsx
"use client";

import React, { useState, ChangeEvent } from "react";

interface PhotoUploadProps {
  onImageSelect: (file: File) => void;
}

export default function PhotoUpload({ onImageSelect }: PhotoUploadProps) {
  const [preview, setPreview] = useState<string | null>(null);

  const [isUploading, setIsUploading] = useState(false);

  const handleFileChange = (e: ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];
    if (file) {
      // 1. Validação de Tipo
      if (!file.type.startsWith("image/")) {
        alert("Por favor, selecione um arquivo de imagem válido.");
        return;
      }

      // 2. Validar Tamanho (Limite 10MB)
      const maxSize = 10 * 1024 * 1024;
      if (file.size > maxSize) {
        alert("A imagem é muito grande! Escolha uma foto de até 10MB.");
        return;
      }

      setIsUploading(true); // Ativa o feedback visual

      // 3. ÚNICA DECLARAÇÃO DO READER
      const reader = new FileReader();

      reader.onloadend = () => {
        setPreview(reader.result as string);
        onImageSelect(file);
        setIsUploading(false); // Sucesso: desativa o carregamento
      };

      reader.onerror = () => {
        alert("Erro ao ler o arquivo.");
        setIsUploading(false); // Erro: desativa o carregamento
      };

      reader.readAsDataURL(file);

      // A segunda declaração que estava aqui foi removida!
    }
  };

  return (
    <div className="flex flex-col items-center gap-4 w-full">
      <label
        htmlFor="photo-upload"
        className={`relative cursor-pointer w-full aspect-[9/16] bg-slate-100 rounded-xl border-2 border-dashed border-slate-300 overflow-hidden hover:bg-slate-200 transition-colors flex items-center justify-center ${isUploading ? "opacity-50 cursor-not-allowed" : ""}`}
      >
        {isUploading ? (
          <div className="flex flex-col items-center gap-2">
            {/* Um spinner simples em CSS */}
            <div className="w-8 h-8 border-4 border-blue-600 border-t-transparent rounded-full animate-spin"></div>
            <p className="text-sm font-medium text-slate-500">
              Processando imagem...
            </p>
          </div>
        ) : preview ? (
          <img
            src={preview}
            alt="Preview"
            className="w-full h-full object-cover"
          />
        ) : (
          <div className="text-center text-slate-500 p-4">
            <p className="text-sm font-bold">Clique para subir sua foto</p>
            <p className="text-xs">PNG, JPG até 10MB</p>
          </div>
        )}

        <input
          id="photo-upload"
          type="file"
          className="hidden"
          accept=".jpg,.jpeg,.png,.webp"
          onChange={handleFileChange}
          disabled={isUploading} // Impede novo upload enquanto processa
        />
      </label>

      {preview && (
        <p className="text-xs text-green-600 font-medium italic">
          Foto carregada com sucesso!
        </p>
      )}
    </div>
  );
}
