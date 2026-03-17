using Atendimento.Domain.DTOs;
using Atendimento.Domain.Entities;
using Atendimento.Domain.Interfaces;
using AutoMapper;

namespace Atendimento.Domain.Services;

public class DepartamentosService : IDepartamentoService
{
    public readonly IDepartamentoRepository _departamentoRepository;
    private readonly IMapper _mapper;

    public DepartamentosService(IDepartamentoRepository departamentoRepository, IMapper mapper)
    {
        _departamentoRepository = departamentoRepository;
        _mapper = mapper;
    }
   public async Task<Response<DepartamentoResponseDto>> CriarDepartamentoAsync(DepartamentoCreateDto departamentosCreateDto)
    {
        Response<DepartamentoResponseDto> resposta = new Response<DepartamentoResponseDto>();

    try
    {
        string aliasLimpo = departamentosCreateDto.Alias.Trim().ToUpper();
        
        var quantidade = await _departamentoRepository.ObterQuantidadeDepartamentosAsync();
        string codigoSugerido = $"{aliasLimpo}{(quantidade + 1).ToString().PadLeft(4, '0')}";

        // 3. Verifica se o código já existe (Causa Raiz: Evitar duplicidade)
        var departamentoExistente = await _departamentoRepository.ObterDepartamentoPorCodEquipeAsync(codigoSugerido);

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

        await _departamentoRepository.AdicionarDepartamentoAsync(novoDepto);

        resposta.Status = true;
        resposta.Mensagem = "Departamento criado com sucesso.";
        resposta.Dados = _mapper.Map<DepartamentoResponseDto>(novoDepto);
        return resposta;
    }
    catch (Exception ex)
    {
        resposta.Mensagem = $"Erro ao criar departamento: {ex.Message}";
        resposta.Status = false;
        return resposta;
    }
}

    public async Task<Response<DepartamentoResponseDto>> ListarDepartamentoPorCodEquipeAsync(string CodDepartamento)
    {
        var resposta = new Response<DepartamentoResponseDto>();

        try
        {
            var departamento = await _departamentoRepository.ObterDepartamentoPorCodEquipeAsync(CodDepartamento);

            if (departamento == null)
            {
                resposta.Mensagem = "Departamento não localizado";
                resposta.Status = false;
                return resposta;
            }

            resposta.Dados = new DepartamentoResponseDto
            {
                Id = departamento.Id,
                Nome = departamento.Nome,
                Alias = departamento.Alias,
                CodDepartamento = departamento.CodDepartamento ?? string.Empty
            };

            resposta.Mensagem = "Departamento localizado";
            resposta.Status = true;
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = $"Erro ao buscar o departamento: {ex.Message}";
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
        Response<List<Departamentos>> resposta = new Response<List<Departamentos>>();

        try
        {
            var departamentos = await _departamentoRepository.ObterDepartamentosAsync();

            if (departamentos == null)
            {
                 resposta.Mensagem = "Departamentos não localizados";
                 resposta.Status = false;
                 return resposta;
            }

            resposta.Mensagem = "Departamentos localizados";
            resposta.Dados = departamentos;
            resposta.Status = true;
                
            return resposta;  
            
        }
        catch(Exception ex)
        {
            
            resposta.Mensagem = $"Erro ao buscar departamentos {ex.Message}";
            resposta.Status = false;
            return resposta;
        }

    }
}

