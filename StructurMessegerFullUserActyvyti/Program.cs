using StructurMessegerFullUserActyvyti.DAL.Repositories;


namespace StructurMessegerFullUserActyvyti;

internal class Program
{
    static async Task Main(string[] args)
    {
        UseAccauntMethodRepository useAccaunt = new();

        await useAccaunt.AccauntMethod();
    } 
}
