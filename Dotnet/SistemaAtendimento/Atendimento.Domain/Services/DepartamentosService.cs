using Atendimento.Domain.DTOs;
using Atendimento.Domain.Entities;
using Atendimento.Domain.Interfaces;

namespace Atendimento.Domain.Services;

public class DepartamentosService : IDepartamentoService
{
    public readonly IDepartamentoRepository _departamentoRepository;

    public DepartamentosService(IDepartamentoRepository departamentoRepository)
    {
        _departamentoRepository = departamentoRepository;
    }
   public async Task<Response<Departamentos>> CriarDepartamentoAsync(DepartamentoCreateDto departamentosCreateDto)
    {
        Response<Departamentos> resposta = new Response<Departamentos>();

    try
    {
        string aliasLimpo = departamentosCreateDto.Alias.Trim().ToUpper();
        
        var quantidade = await _departamentoRepository.ObterQuantidadeDepartamentos();
        string codigoSugerido = $"{aliasLimpo}{(quantidade + 1).ToString().PadLeft(4, '0')}";

        // 3. Verifica se o código já existe (Causa Raiz: Evitar duplicidade)
        var departamentoExistente = await _departamentoRepository.ObterDepartamentoPorCodEquipe(codigoSugerido);

        if (departamentoExistente != null)
        {
            resposta.Status = false;
            resposta.Mensagem = $"O código {codigoSugerido} já está em uso.";
            return resposta;
        }

        
        var novoDepto = new Departamentos()
        {
            Nome = departamentosCreateDto.Nome,
            Alias = aliasLimpo,
            CodDepartamento = codigoSugerido 
        };

        await _departamentoRepository.AdicionarDepartamento(novoDepto);

        resposta.Status = true;
        resposta.Mensagem = "Departamento criado com sucesso.";
        resposta.Dados = novoDepto;
        return resposta;
    }
    catch (Exception ex)
    {
        resposta.Mensagem = $"Erro ao criar departamento: {ex.Message}";
        resposta.Status = false;
        return resposta;
    }
}

    public async Task<Response<Departamentos>> ListarDepartamentoPorCodEquipeAsync(string CodDepartamento)
    {
        Response<Departamentos> resposta = new Response<Departamentos>();

        try
        {
            var departamento = await _departamentoRepository.ObterDepartamentoPorCodEquipe(CodDepartamento);

            if (departamento == null)
            {
                resposta.Mensagem = "Departamento não localizado";
                resposta.Status = false;
                return resposta;
            }

                resposta.Mensagem = "Departamento localizado";
                resposta.Status = true;
                resposta.Dados = departamento;

                return resposta;
            
        }
        catch (Exception ex)
        {
            
            resposta.Mensagem = $"Erro ao buscar o Id: {ex.Message}";
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<Response<Departamentos>> ListarDepartamentoPorIdAsync(int Id)
    {
        Response<Departamentos> resposta = new Response<Departamentos>();

        try
        {
            var departamento = await _departamentoRepository.ObterDepartamentoPorIdAsync(Id);

            if (departamento == null)
            {
                resposta.Mensagem = "Departamento não localizado";
                resposta.Status = false;
                return resposta;
            }

            resposta.Mensagem = "Departamento localizado";
                resposta.Status = true;
                resposta.Dados = departamento;

                return resposta;
            }
        catch (Exception ex)
        {
            
            resposta.Mensagem = $"Erro ao buscar o Id: {ex.Message}";
            resposta.Status = false;
            return resposta;
        }

    }

    public async Task<Response<List<Departamentos>>> ListarDepartamentosAsync()
    {
        Response<Departamentos> resposta = new Response<Departamentos>();

        try
        {
            var departamento = await _departamentoRepository.ObterDE
            
        }
        catch(Exception ex)
        {
            
            resposta.Mensagem = $"Erro ao buscar o Id: {ex.Message}";
            resposta.Status = false;
            return resposta;
        }

    }
}

