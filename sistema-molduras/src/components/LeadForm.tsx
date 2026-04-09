"use client";

import { useState, ChangeEvent } from "react";

const DDD_VALIDOS = [
  11, 12, 13, 14, 15, 16, 17, 18, 19, 21, 22, 24, 27, 28, 31, 32, 33, 34, 35,
  37, 38, 41, 42, 43, 44, 45, 46, 47, 48, 49, 51, 53, 54, 55, 61, 62, 63, 64,
  65, 66, 67, 68, 69, 71, 73, 74, 75, 77, 79, 81, 82, 83, 84, 85, 86, 87, 88,
  89, 91, 92, 93, 94, 95, 96, 97, 98, 99,
];

interface LeadFormProps {
  onSubmit: (data: { nome: string; whatsapp: string }) => void;
}

export default function LeadForm({ onSubmit }: LeadFormProps) {
  const [nome, setNome] = useState("");
  const [whatsapp, setWhatsapp] = useState("");
  const [erro, setErro] = useState("");

  // SANITIZAÇÃO EM TEMPO REAL (Anti-XSS na entrada)
  const handleNomeChange = (e: ChangeEvent<HTMLInputElement>) => {
    const input = e.target.value;

    // 1. Remove tags HTML e caracteres de script perigosos instantaneamente
    // 2. Permite apenas letras, espaços e acentuação básica
    const sanitizado = input
      .replace(/<[^>]*>?/gm, "") // Remove tags HTML
      .replace(/[<>{}|[\]\\]/g, "") // Remove caracteres de escape de script
      .replace(/[0-9]/g, ""); // Nomes geralmente não possuem números

    setNome(sanitizado);
    if (erro) setErro("");
  };

  const handlePhoneChange = (e: ChangeEvent<HTMLInputElement>) => {
    let value = e.target.value.replace(/\D/g, "");
    if (value.length <= 11) {
      value = value.replace(/^(\d{2})(\d)/g, "($1) $2");
      value = value.replace(/(\d{5})(\d)/, "$1-$2");
      setWhatsapp(value);
      setErro("");
    }
  };

  const validarLead = () => {
    // Double-check de segurança antes do submit
    const nomeFinal = nome.trim();

    // Validação de DDD
    const ddd = parseInt(whatsapp.substring(1, 3));
    if (!DDD_VALIDOS.includes(ddd)) {
      setErro("DDD inválido. Por favor, use um DDD real do Brasil.");
      return;
    }

    // Bloqueio de números repetidos óbvios
    const apenasNumeros = whatsapp.replace(/\D/g, "");
    if (/^(\d)\1+$/.test(apenasNumeros.substring(2))) {
      setErro("Por favor, insira um número de telefone válido.");
      return;
    }

    onSubmit({ nome: nomeFinal, whatsapp: apenasNumeros });
  };

  const isFormValid = nome.trim().length >= 3 && whatsapp.length >= 14;

  return (
    <div className="w-full bg-white p-6 rounded-2xl shadow-xl border border-slate-100 flex flex-col gap-4 animate-in fade-in zoom-in-95">
      <div className="text-center mb-2">
        <h3 className="text-lg font-black text-blue-900 uppercase italic leading-tight">
          Quase lá!
        </h3>
        <p className="text-[10px] text-slate-400 font-bold uppercase tracking-widest">
          Identificação de Segurança
        </p>
      </div>

      <div className="flex flex-col gap-3">
        <input
          type="text"
          placeholder="Seu Nome Completo"
          value={nome}
          onChange={handleNomeChange}
          className="w-full p-3 bg-slate-50 border border-slate-200 rounded-xl text-sm focus:ring-2 focus:ring-blue-500 outline-none transition-all"
          maxLength={50}
        />
        <input
          type="text"
          placeholder="WhatsApp (00) 00000-0000"
          value={whatsapp}
          onChange={handlePhoneChange}
          className="w-full p-3 bg-slate-50 border border-slate-200 rounded-xl text-sm font-mono focus:ring-2 focus:ring-blue-500 outline-none transition-all"
        />

        {erro && (
          <div className="bg-red-50 p-2 rounded-lg border border-red-100">
            <p className="text-[10px] text-red-500 font-bold text-center">
              {erro}
            </p>
          </div>
        )}
      </div>

      <button
        disabled={!isFormValid}
        onClick={validarLead}
        className={`w-full py-4 rounded-xl font-black uppercase text-xs tracking-widest transition-all ${
          isFormValid
            ? "bg-blue-600 text-white shadow-lg active:scale-95"
            : "bg-slate-100 text-slate-400 cursor-not-allowed"
        }`}
      >
        Validar e Liberar
      </button>

      <p className="text-[8px] text-slate-300 text-center uppercase leading-tight">
        Ao continuar, você autoriza o contato <br /> para fins informativos.
      </p>
    </div>
  );
}
