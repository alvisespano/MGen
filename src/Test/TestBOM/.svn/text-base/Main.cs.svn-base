
using GenTest.BOM;
using Caffettiera.CSharp.BLL.BOM;

class Program
{

    public static void Main(string[] args)
    {
        var env = new Env<Transaction>();

        Fattura f = new Fattura(env);

        RigaFattura rf1 = new RigaFattura(env);
        RigaFattura rf2 = new RigaFattura(env);
        RigaFattura rf3 = new RigaFattura(env);

        f.Commit();
        rf1.Commit();
        rf2.Commit();
        rf3.Commit();
   
        f.AggregationRigaFattura.Add(rf1);
        f.AggregationRigaFattura.Add(rf2);
        f.AggregationRigaFattura.Add(rf3);
        f.Commit();

        f.AggregationRigaFattura.Remove(rf2);
        f.Commit();

        f.StampaRighe(1, 3);

        env.FailsafeTransactionalCommit();

    }
}