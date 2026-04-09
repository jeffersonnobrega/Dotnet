import { supabase } from "@/lib/supabase";
import CanvasEditor from "@/components/CanvasEditor";
import { notFound } from "next/navigation";
import { getCandidatoTheme } from "@/lib/theme-mapper";
import {
  Users,
  Camera,
  Share2,
  ShieldCheck,
  Camera as CameraIcon,
} from "lucide-react";

interface PageProps {
  params: Promise<{ slug: string }>;
}

export const dynamic = "force-dynamic";
export const fetchCache = "force-no-store";

export default async function CandidatoPage({ params }: PageProps) {
  const { slug } = await params;

  const { data: candidato, error: candidatoError } = await supabase
    .from("candidatos")
    .select("*")
    .eq("slug", slug)
    .single();

  if (candidatoError || !candidato) {
    return notFound();
  }

  const { data: countData } = await supabase.rpc("get_leads_count", {
    slug_candidato: slug,
  });

  const cor = candidato.cor_primaria;
  const theme = getCandidatoTheme(cor); // O tema agora já traz o 'contrast' calculado internamente
  const leadsEfetivos = Number(countData?.[0]?.total_count || 0);
  const visualizacoesBase = 1540;

  return (
    <div
      className={`min-h-screen ${theme.page.bg} ${theme.page.textPrincipal} font-sans ${theme.page.selection} scroll-smooth`}
    >
      {/* NAVBAR (Estrutura mantida, cores agora vêm 100% do theme-mapper) */}
      <nav
        className={`sticky top-0 z-50 ${theme.nav.bg} backdrop-blur-md border-b ${theme.nav.border} px-4 md:px-6 py-4`}
      >
        <div className="max-w-7xl mx-auto flex justify-between items-center gap-4">
          <a
            href="#"
            className="flex items-center gap-2 hover:opacity-70 transition-all group"
          >
            <div
              className="w-8 h-8 rounded-full shadow-inner border border-white"
              style={{ backgroundColor: cor }}
            ></div>
            <span
              className={`font-black text-xl md:text-2xl uppercase tracking-tighter italic leading-none ${theme.nav.logoText}`}
            >
              {candidato.nome_urna}
            </span>
          </a>
          <a
            href="#criar"
            className="px-6 py-2 rounded-full shadow-lg transition-all active:scale-95 flex items-center justify-center"
            style={{
              backgroundColor: theme.nav.button.bg, // corBase
              border: theme.nav.button.border, // contrast com opacidade
            }}
          >
            <span
              className="text-[10px] font-black uppercase tracking-widest"
              style={{ color: theme.nav.button.text }} // Dinâmico (Preto ou Branco)
            >
              Fazer minha foto
            </span>
          </a>
        </div>
      </nav>

      {/* SEÇÃO PRINCIPAL UNIFICADA (HERO + EDITOR LADO A LADO) */}
      <section
        id="criar"
        className={`relative pt-12 pb-24 px-6 overflow-hidden ${theme.sections.editorBg} scroll-mt-20`}
      >
        <div className="max-w-7xl mx-auto relative z-10">
          <div className="grid grid-cols-1 lg:grid-cols-2 gap-12 lg:gap-20 items-start">
            {/* COLUNA ESQUERDA: TEXTOS (HERO) */}
            <div className="text-center lg:text-left space-y-8 lg:sticky lg:top-32 animate-in fade-in slide-in-from-left-4 duration-500">
              <div>
                <span
                  className={`text-[10px] font-black uppercase tracking-[0.4em] ${theme.page.textMuted} block mb-2`}
                >
                  Ferramenta Oficial
                </span>
                <h1
                  className={`text-6xl md:text-8xl lg:text-9xl font-black uppercase italic leading-[0.85] tracking-tighter mb-6 ${theme.hero.title}`}
                >
                  Crie sua foto <br />
                  <span style={{ color: theme.hero.accent }}>Oficial</span>
                </h1>
                <p
                  className={`${theme.page.textSecundario} text-xl md:text-2xl font-medium max-w-2xl mx-auto lg:mx-0 text-balance`}
                >
                  Apoie a campanha de {candidato.nome_urna}. Personalize sua
                  foto de perfil em segundos e mostre que você faz parte da
                  mudança.
                </p>
              </div>

              {/* DICAS RÁPIDAS */}
              <div className="hidden lg:grid grid-cols-3 gap-6 pt-8 border-t border-slate-200">
                {[
                  { id: 1, text: "Suba sua melhor foto" },
                  { id: 2, text: "Ajuste o enquadramento" },
                  { id: 3, text: "Baixe e compartilhe no Zap" },
                ].map((step) => (
                  <div key={step.id} className="flex items-center gap-4">
                    <div
                      className={`w-10 h-10 rounded-full ${theme.cards.iconBg} flex items-center justify-center font-black text-xs`}
                      style={{ color: cor }}
                    >
                      {step.id}
                    </div>
                    <p className="text-sm font-bold uppercase tracking-wider text-slate-500">
                      {step.text}
                    </p>
                  </div>
                ))}
              </div>
            </div>

            {/* COLUNA DIREITA: CONTAINER DO EDITOR */}
            <div className="relative animate-in fade-in slide-in-from-right-4 duration-500">
              <div
                className="absolute -inset-4 opacity-10 blur-3xl rounded-full pointer-events-none"
                style={{ backgroundColor: cor }}
              ></div>

              <div
                className={`relative ${theme.editor.containerBg} p-2 md:p-4 rounded-[2.5rem] md:rounded-[3rem] ${theme.editor.shadow} border ${theme.editor.containerBorder} overflow-hidden max-w-[320px] mx-auto transition-all`}
              >
                <CanvasEditor
                  candidatoId={candidato.slug}
                  corPrimaria={cor}
                  molduraUrl={candidato.url_moldura}
                  theme={theme.editor}
                />
              </div>
            </div>
          </div>
        </div>

        <div
          className="absolute top-0 left-1/2 -translate-x-1/2 w-[800px] h-[800px] opacity-[0.05] pointer-events-none rounded-full blur-3xl"
          style={{ backgroundColor: cor }}
        ></div>
      </section>

      {/* STATS SECTION */}
      <section
        className={`${theme.sections.statsBg} border-y ${theme.sections.statsBorder} py-12 px-6 text-center`}
      >
        <div className="max-w-5xl mx-auto grid grid-cols-1 md:grid-cols-3 gap-12">
          {[
            {
              label: "Visualizações",
              value: leadsEfetivos + visualizacoesBase,
              border: false,
            },
            { label: "Fotos Baixadas", value: leadsEfetivos, border: true },
            {
              label: "Compartilhamentos",
              value: Math.floor(leadsEfetivos * 0.4),
              border: false,
            },
          ].map((stat, idx) => (
            <div
              key={idx}
              className={`space-y-1 ${stat.border ? `md:border-x ${theme.stats.divider}` : ""}`}
            >
              <h3
                className="text-5xl font-black tabular-nums tracking-tighter"
                style={{ color: theme.stats.number }}
              >
                {stat.value.toLocaleString("pt-BR")}
              </h3>
              <p
                className={`text-[10px] font-black uppercase tracking-[0.3em] ${theme.stats.label}`}
              >
                {stat.label}
              </p>
            </div>
          ))}
        </div>
      </section>

      {/* FOOTER */}
      <footer
        className={`py-12 px-6 ${theme.footer.bg} border-t ${theme.footer.border} text-center`}
      >
        <p
          className={`text-[10px] font-black uppercase tracking-[0.5em] ${theme.footer.text}`}
        >
          SIND - Sistema de Molduras Digitais
        </p>
        <p className={`mt-4 text-[9px] ${theme.footer.copy} font-medium`}>
          {new Date().getFullYear()} Todos os direitos reservados.
        </p>
      </footer>
    </div>
  );
}
