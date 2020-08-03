using PiHoleApiClient.Models;
using System.Collections.Generic;
using System.Linq;

namespace PiHoleApiClient.Mappers
{
    public static class QueryMapper
    {
        public static List<Query> MapQueries(this PreQuery preQuery)
        {
            if (preQuery == null) return new List<Query>();
            return preQuery?.Data?.Select(q => new Query(q[0], q[1], q[2], q[3], q[4])).ToList();
        }
    }
}
