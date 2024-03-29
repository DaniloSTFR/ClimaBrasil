

using ClimaBrasil.Domain.Abstractions;
using ClimaBrasil.Domain.Entities;
using ClimaBrasil.Infrastructure.Factoy;
using ClimaBrasil.Infrastructure.Queries.Input;
using ClimaBrasil.Infrastructure.Queries.Output;
using Dapper;
using System.Data;

namespace ClimaBrasil.Infrastructure.Repositories
{
    public class CidadesClimaRepository : ICidadesClimaRepository
    {
        private readonly IClimaRepository _climaRepository;
        private readonly IDbConnection _dbConnection;

        public CidadesClimaRepository(IClimaRepository climaRepository, SqlFactory factory)
        {
            _climaRepository = climaRepository;
            _dbConnection = factory.SqlConnection();
        }

        public async Task<CidadeEntity> AddClimaCidade(CidadeEntity climaCidade)
        {

            if (climaCidade is null)
                throw new ArgumentNullException(nameof(climaCidade));

            var query = new InsertCidadeClimaQuery().InsertCidadeClimaQueryModel(climaCidade,true);
            try
            {
                using (_dbConnection)
                {
                    var climaCidadeID = await _dbConnection.ExecuteScalarAsync(query.Query, query.Parameters);
                    if (climaCidadeID is not null)
                    {
                        climaCidade.Id = Int32.Parse(climaCidadeID.ToString());
                        _climaRepository.AddClima(climaCidade.Clima,climaCidade.Id);
                    }
                    else {
                        climaCidade.Id = 0;
                    }
                }   
            }
            catch
            {
                throw new Exception("Erro ao inserir Clima da Cidade.");
            }

            return climaCidade;
        }

        public async Task<CidadeEntity> DeleteClimaCidade(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            var cidade = await GetClimaCidadeById(id);

            if (cidade is not null)
            {
                var query = new DeleteCidadeClimaByIdQuery().DeleteCidadeClimaByIdQueryModel(id);
                try
                {
                    using (_dbConnection)
                    {
                        //_climaRepository.DeleteClimaByIdCidade(id);
                        await _dbConnection.ExecuteAsync(query.Query, query.Parameters);
                    }   
                }
                catch(Exception e)
                {
                    throw new Exception("Erro ao excluir o Clima da Cidade.");
                }
            }
            return cidade;
        }

        public async Task<IEnumerable<CidadeEntity>> GetClimaCidade()
        {
            var query = new SelectAllCidadeClimaQuery().SelectAllCidadeClimaQueryModel();
            return await _dbConnection.QueryAsync<CidadeEntity>(query.Query);
        }

        // TODO: Avaliar os retornos pois envolvem mais de uma tabela, usar Inner join
        public async Task<CidadeEntity> GetClimaCidadeById(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            CidadeEntity cidadeClima;
            var queryCidade = new SelectCidadeClimaByIdQuery().SelectCidadeClimaByIdQueryModel(id);
            var queryClima = new SelectCidadeClimaByIdQuery().SelectClimaByIdCidadeQueryModel(id);

            try
            {
                using (_dbConnection)
                {
                    var resulCidade = await _dbConnection.QueryFirstOrDefaultAsync<CidadeEntity>(queryCidade.Query, queryCidade.Parameters);
                    var resultClima = await _dbConnection.QueryAsync<ClimaEntity>(queryClima.Query, queryClima.Parameters) as List<ClimaEntity>;

                    cidadeClima = new CidadeEntity(resulCidade.Id,
                                                    resulCidade.CodigoCidade,
                                                    resulCidade.Cidade,
                                                    resulCidade.Estado,
                                                    resulCidade.AtualizadoEm,
                                                    resultClima,
                                                    resulCidade.RotaRequest);
                }   
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao buscar o Clima da Cidade.");
            }

            return cidadeClima;
        }

        public void UpdateClimaCidade(CidadeEntity climaCidade)
        {
            throw new NotImplementedException();
        }
    }
}