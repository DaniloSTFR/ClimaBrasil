using ClimaBrasil.Domain.Validation;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClimaBrasil.Domain.Entities
{
    public class Clima : BaseEntity
    {

        #region  External Props

        public DateTime? Data { get; private set; }
        public string? Condicao { get; private set; }
        public int? Min { get; private set; }
        public int? Max { get; private set; }
        public float? IndiceUv { get; private set; }
        public string? CondicaoDesc { get; private set; }

        #endregion

        public Clima()
        {
        }

        public Clima(DateTime? data, string? condicao, int? min, int? max, int? indiceUv, 
                    string? condicaoDesc)
        {
            ValidateDomain( data, condicao, min, max, indiceUv, condicaoDesc);
        }

        [JsonConstructor]
        public Clima(int id, DateTime? data, string? condicao, int? min, int? max, 
                    float? indiceUv, string? condicaoDesc)
        {
            DomainValidation.When(string.IsNullOrEmpty(id.ToString()), "Id é inválido.");
            Id = id;
            ValidateDomain( data, condicao, min, max, indiceUv, condicaoDesc);
        }

        
        public void Update(DateTime? data, string? condicao, int? min, int? max, 
                                    float? indiceUv, string? condicaoDesc)
        {
            ValidateDomain( data, condicao, min, max, indiceUv, condicaoDesc);
        }

        private void ValidateDomain(DateTime? data, string? condicao, int? min, int? max, 
                                    float? indiceUv, string? condicaoDesc)

        {
            DomainValidation.When(data == null,
                "Data é inválido. Data é Requerido.");

            DomainValidation.When(string.IsNullOrEmpty(condicao),
                "Condicao é inválido. Nome é Condicao.");

            DomainValidation.When(min == null,
                "Temperatura minima é inválido. Temperatura minima é Requerido.");

            DomainValidation.When(max  == null,
                "Temperatura máxima é inválido. Temperatura máxima é Requerido.");

            DomainValidation.When(indiceUv == null,
                "O valor máximo diário da radiação ultravioleta. O valor é Requerido.");

            DomainValidation.When(string.IsNullOrEmpty(condicaoDesc),
                "O código da condição meteorológica é inválido. O código é Requerido.");


            Data = data;
            Condicao = condicao;
            Min = min;
            Max = max;
            IndiceUv = indiceUv;
            CondicaoDesc = condicaoDesc;

        }
        
    }
}