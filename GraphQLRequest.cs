using Newtonsoft.Json.Linq;

namespace HackMidwest2018Backend{
public class GraphQLRequest
    {
        public string OperationName { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}