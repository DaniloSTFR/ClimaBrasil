using ClimaBrasil.Domain.Validation;
using System.Text.Json.Serialization;

namespace ClimaBrasil.Domain.Entities
{
    public class AeroportoEntity : BaseEntity
    {
        #region  External Props
        public string? CodigoAeroporto { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public int? PressaoAtmosferica { get; set; }
        public string? Visibilidade { get; set; }
        public int? Vento { get; set; }
        public int? DirecaoVento { get; set; }
        public int? Umidade { get; set; }
        public string? Condicao { get; set; }
        public string? CondicaoDesc { get; set; }
        public float? Temp { get; set; }   
        #endregion 

        public AeroportoEntity()
        {
        }

        public AeroportoEntity(string? codigoAeroporto, DateTime? atualizadoEm, int? pressaoAtmosferica, string? visibilidade, 
                            int? vento, int? direcaoVento, int? umidade, string? condicao, string? condicaoDesc, float? temp)
        {
            CodigoAeroporto = codigoAeroporto;
            AtualizadoEm = atualizadoEm;
            PressaoAtmosferica = pressaoAtmosferica;
            Visibilidade = visibilidade;
            Vento = vento;
            DirecaoVento = direcaoVento;
            Umidade = umidade;
            Condicao = condicao;
            CondicaoDesc = condicaoDesc;
            Temp = temp;
        }

        private void ValidateDomain(string? codigoAeroporto, DateTime? atualizadoEm, int? pressaoAtmosferica, string? visibilidade, 
                                int? vento, int? direcaoVento, int? umidade, string? condicao, string? condicaoDesc, float? temp)
        {

            DomainValidation.When(string.IsNullOrEmpty(codigoAeroporto),
                "Código ICAO do aeroporto é inválido. O código é Requerido.");

            DomainValidation.When(atualizadoEm == null,
                "Data é inválido. Data é Requerido.");

            DomainValidation.When(pressaoAtmosferica == null,
                "Pressão atmosférica é inválido. O valor é Requerido.");

            DomainValidation.When(string.IsNullOrEmpty(visibilidade),
                "A visibilidade é inválido. O valor é Requerido.");

            DomainValidation.When(vento == null,
                "Intensidade do vendo é inválido. O valor é Requerido.");

            DomainValidation.When(direcaoVento == null,
                "Direção do vento é inválido. O valor é Requerido.");

            DomainValidation.When(umidade == null,
                "Umidade relativa do ar é inválido. O valor de Umidade é Requerido.");

            DomainValidation.When(temp == null,
                "Temperatura (em graus celsius) é inválido. O valor é Requerido.");
           
            
            CodigoAeroporto = codigoAeroporto;
            AtualizadoEm = atualizadoEm;
            PressaoAtmosferica = pressaoAtmosferica;
            Visibilidade = visibilidade;
            Vento = vento;
            DirecaoVento = direcaoVento;
            Umidade = umidade;
            Condicao = condicao;
            CondicaoDesc = condicaoDesc;
            Temp = temp;
        }
        
    }
}