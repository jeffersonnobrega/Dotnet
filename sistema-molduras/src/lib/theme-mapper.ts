// src/lib/theme-mapper.ts

/**
 * Calcula se o texto deve ser preto ou branco com base na cor de fundo
 * para garantir acessibilidade (WCAG).
 */
function getContrastColor(hexColor: string) {
  if (!hexColor) return "#ffffff";
  const hex = hexColor.replace("#", "");

  const r = parseInt(hex.substring(0, 2), 16);
  const g = parseInt(hex.substring(2, 4), 16);
  const b = parseInt(hex.substring(4, 6), 16);

  // Fórmula YIQ para percepção de brilho
  const yiq = (r * 299 + g * 587 + b * 114) / 1000;

  // Se a cor for clara (yiq >= 128), retorna preto, senão retorna branco
  return yiq >= 128 ? "#000000" : "#ffffff";
}

export function getCandidatoTheme(corBase: string) {
  // Calculamos o contraste uma vez para usar no tema
  const contrast = getContrastColor(corBase);

  // Função auxiliar para transparências (opcional, caso queira usar em bordas)
  const withOpacity = (hex: string, opacity: number) => {
    const op = Math.round(opacity * 255)
      .toString(16)
      .padStart(2, "0");
    return `${hex}${op}`;
  };

  return {
    // CORES GERAIS DE PÁGINA
    page: {
      bg: "bg-white",
      selection: "selection:bg-slate-200",
      textPrincipal: "text-slate-900",
      textSecundario: "text-slate-500",
      textMuted: "text-slate-400",
    },

    // NAVBAR
    nav: {
      bg: "bg-white/90",
      border: "border-slate-100",
      logoText: "text-slate-900",
      button: {
        bg: corBase,
        text: contrast, // Dinâmico: Preto se fundo claro, Branco se fundo escuro
        border: `1px solid ${withOpacity(contrast, 0.1)}`,
      },
    },

    // SEÇÕES (FUNDOS)
    sections: {
      heroBg: "bg-slate-50/50",
      statsBg: "bg-white",
      statsBorder: "border-slate-100",
      howItWorksBg: "bg-slate-50/30",
      editorBg: "bg-slate-50",
    },

    // COMPONENTES ESPECÍFICOS
    hero: {
      title: "text-slate-900",
      accent: corBase,
      badgeBg: "bg-white",
      badgeBorder: "border-slate-100",
      badgeText: "text-slate-400",
    },

    stats: {
      number: corBase,
      label: "text-slate-400",
      divider: "md:border-slate-100",
    },

    cards: {
      bg: "bg-white",
      border: "border-slate-100",
      iconBg: "bg-slate-50",
      iconColor: corBase,
      title: "text-slate-900",
      desc: "text-slate-500",
    },

    // EDITOR E CANVAS
    editor: {
      containerBg: "bg-white",
      containerBorder: "border-white",
      shadow: "shadow-slate-200/50",
      canvasBg: "bg-slate-100",
      canvasBorder: "#ffffff",
      instructions: "text-slate-400",

      // Controles Internos
      controls: {
        label: "text-slate-400",
        value: corBase,
        trackBg: "#f1f5f9",
        btnBg: "bg-slate-50",
        btnHover: "hover:bg-slate-100",
        btnReset: corBase,
        btnSwapPhoto: "text-red-500",
        btnSwapPhotoBg: "bg-red-50",
      },

      // Botão de Download (O principal)
      downloadBtn: {
        bg: corBase,
        text: contrast, // Dinâmico aqui também
        shadow: "shadow-lg",
      },
    },

    // FOOTER
    footer: {
      bg: "bg-white",
      border: "border-slate-100",
      text: "text-slate-400",
      copy: "text-slate-300",
    },
  };
}

// Exportamos o tipo para usar no TypeScript
export type CandidatoTheme = ReturnType<typeof getCandidatoTheme>;
