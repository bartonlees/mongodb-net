//COPYRIGHT

namespace MongoDB.Driver
{

    public class MapReduceInfo
    {
        public MapReduceInfo(IDBCollection from, DBObject raw)
        {
            ResultingCollection = from.Database.GetCollection(raw.GetAsString("result"));
            Counts = (IDocument)raw["counts"];
        }

        public IDBCollection ResultingCollection { get; private set;}
        public IDocument Counts { get; private set;}
    }
}