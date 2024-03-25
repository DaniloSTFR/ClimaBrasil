using ClimaBrasil.Domain.Validation;
using System.Text.Json.Serialization;

namespace ClimaBrasil.Domain.Entities
{
    public class CidadeEntity: BaseEntity
    {

        #region  External Props
        public string? Cidade { get; private set; }
        public string? Estado { get; private set; }
        public DateTime? AtualizadoEm { get; private set; }
        public List<ClimaEntity>? Clima { get; private set; }

        #endregion

        public CidadeEntity()
        {
        }

        public CidadeEntity(string? cidade, string? estado, DateTime? atualizadoEm, List<ClimaEntity>? clima)
        {
            ValidateDomain(cidade, estado, atualizadoEm, clima);
        }

        [JsonConstructor]
        public CidadeEntity(int id, string? cidade, string? estado, DateTime? atualizadoEm, List<ClimaEntity>? clima)
        {
            DomainValidation.When(string.IsNullOrEmpty(id.ToString()), "Id é inválido.");
            Id = id;
            ValidateDomain(cidade, estado, atualizadoEm, clima);
        }

        public void Update(int id, string? cidade, string? estado, DateTime? atualizadoEm, List<ClimaEntity>? clima)
        {
            ValidateDomain(cidade, estado, atualizadoEm, clima);
        }

         private void ValidateDomain(string? cidade, string? estado, DateTime? atualizadoEm, List<ClimaEntity>? clima)
         {

            DomainValidation.When(string.IsNullOrEmpty(cidade),
                "O nome da cidade é inválido. O nome é Requerido.");

            //TODO: implementar validação por estado cria enum
            DomainValidation.When(string.IsNullOrEmpty(estado),
                "A UF é inválido. A UF é Requerido.");

            DomainValidation.When(atualizadoEm == null,
                "A Data de atualização é inválido. A Data de atualização é Requerido.");

            DomainValidation.When(clima == null,
                "Clima é inválido. O valores do Clima é Requerido.");



            Cidade = cidade;
            Estado = estado;
            AtualizadoEm = atualizadoEm;
            Clima = clima;
         }

        
    }
}