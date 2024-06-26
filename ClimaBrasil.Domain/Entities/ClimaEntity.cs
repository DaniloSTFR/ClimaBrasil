using ClimaBrasil.Domain.Validation;
using System.Text.Json.Serialization;

namespace ClimaBrasil.Domain.Entities
{
    public class ClimaEntity : BaseEntity
    {

        #region  External Props

        public int? IdCidadeClima { get; set; }
        public DateTime? Data { get; private set; }
        public string? Condicao { get; private set; }
        public int? Min { get; private set; }
        public int? Max { get; private set; }
        public float? IndiceUv { get; private set; }
        public string? CondicaoDesc { get; private set; }

        #endregion

        public ClimaEntity()
        {
        }

        public ClimaEntity(int? idCidadeClima, DateTime? data, string? condicao, int? min, int? max, int? indiceUv, 
                    string? condicaoDesc)
        {
            ValidateDomain(idCidadeClima, data, condicao, min, max, indiceUv, condicaoDesc);
        }

        [JsonConstructor]
        public ClimaEntity(int id, int? idCidadeClima, DateTime? data, string? condicao, int? min, int? max, 
                    float? indiceUv, string? condicaoDesc)
        {
            DomainValidation.When(string.IsNullOrEmpty(id.ToString()), "Id é inválido.");
            Id = id;
            ValidateDomain(idCidadeClima, data, condicao, min, max, indiceUv, condicaoDesc);
        }

        
        public void Update(int? idCidadeClima,DateTime? data, string? condicao, int? min, int? max, 
                                    float? indiceUv, string? condicaoDesc)
        {
            ValidateDomain(idCidadeClima, data, condicao, min, max, indiceUv, condicaoDesc);
        }

        private void ValidateDomain(int? idCidadeClima, DateTime? data, string? condicao, int? min, int? max, 
                                    float? indiceUv, string? condicaoDesc)

        {
            DomainValidation.When(idCidadeClima == null,
                "IdCidadeClima é inválido. O Id é Requerido.");

            DomainValidation.When(data == null,
                "Data é inválido. Data é Requerido.");

            DomainValidation.When(string.IsNullOrEmpty(condicao),
                "Condicao é inválido. Nome é Requerido.");

            DomainValidation.When(min == null,
                "Temperatura minima é inválido. Temperatura minima é Requerido.");

            DomainValidation.When(max  == null,
                "Temperatura máxima é inválido. Temperatura máxima é Requerido.");

            DomainValidation.When(indiceUv == null,
                "O valor máximo diário da radiação ultravioleta. O valor é Requerido.");

            DomainValidation.When(string.IsNullOrEmpty(condicaoDesc),
                "O código da condição meteorológica é inválido. O código é Requerido.");

            IdCidadeClima = idCidadeClima; 
            Data = data;
            Condicao = condicao;
            Min = min;
            Max = max;
            IndiceUv = indiceUv;
            CondicaoDesc = condicaoDesc;

        }
        
    }
}