using Newtonsoft.Json;

namespace CharacterImport.Dto.DnDBeyond
{
    public class ResponseDto
    {
        public bool Success { get; set; }

        [JsonProperty("data")]
        public CharacterDto Character { get; set; }
    }
}
