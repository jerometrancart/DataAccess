using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using DataAccess;


///STRUCTURE DU LIEN GOOGLABLE + TRUSTSERVERCERTIFICATE EN DEHORS DE LA PROD
SqlConnection connection = new SqlConnection("Server=localhost;Database=ApprendreCsharp;User Id=sa;Password=Passw0rd*;TrustServerCertificate=True");

///5 - CREATE WITH DAPPER 
/*connection.Execute(
    "INSERT INTO Personnes(Nom, Prenom) VALUES(@Nom, @Prenom)",
    new
    {
        Nom = "GRANDE",
        Prenom = "Ariana"
    }); */

///6 - READ WITH DAPPER
var personnes = connection.Query<Personne>("SELECT * FROM Personnes");
foreach (var personne in personnes)
{
    System.Console.WriteLine($"{personne.Nom} {personne.Prenom}");
}

///PAS BESOIN D OUVRIR LA CONNECTION AVEC DAPPER
/// connection.Open();

try 
{
    System.Console.WriteLine("Connexion ouverte !");

    /*///1 - CREATE
    SqlCommand command = connection.CreateCommand();
    string? nom = "";
    string? prenom = "";

    while (string.IsNullOrWhiteSpace(prenom)) 
    {
        System.Console.WriteLine("Veuillez saisir votre prénom :");
        prenom = Console.ReadLine();
    }
    
    while (string.IsNullOrWhiteSpace(nom)) 
    {
        System.Console.WriteLine("Veuillez saisir votre nom :");
        nom = Console.ReadLine();
    }

    command.CommandText = "INSERT INTO Personnes(Nom, Prenom) VALUES (@Nom, @Prenom)";

    ///PROTEGE CONTRE LES INJECTIONS SQL AVEC DES PARAMS (ADD, ADDRANGE, ADDWITHVALUE)
    SqlParameter nomParam = new SqlParameter
    {
        DbType = System.Data.DbType.String,
        ParameterName = "@Nom",
        Value = nom
    };
    SqlParameter prenomParam = new SqlParameter
    {
        DbType = System.Data.DbType.String,
        ParameterName = "@Prenom",
        Value = prenom
    };
    command.Parameters.AddRange(new[] { nomParam, prenomParam});


    ///COMMANDE QUI NE RETOURNE PAS DE VALEUR
    var result = command.ExecuteNonQuery();

    if(result > 0)
    {
        System.Console.WriteLine("Insertion effectuée avec succès !");
    } */

    ///2 - READ
    // SqlCommand command = new SqlCommand(
    //     "SELECT * FROM Personnes",
    //     connection
    //     );
    
    ///COMMANDE QUI RETOURNE UNE INSTANCE DE SQLDATAREADER
    /* SqlDataReader reader = command.ExecuteReader();
    while(reader.Read() == true)
    {
        var nom = reader.GetString(reader.GetOrdinal("Nom"));
        var prenom = reader.GetString(reader.GetOrdinal("Prenom"));
        System.Console.WriteLine($"{prenom} {nom}");
    } */

    ///3 - DATATABLES

    ///DECLARE TABLE
    /*DataTable table = new DataTable("Personnes");

    ///COLONNES
    DataColumn id = new DataColumn("Id", typeof(int));
    DataColumn nom = new DataColumn("Nom", typeof(string));
    DataColumn prenom = new DataColumn("Prenom", typeof(string));
    table.Columns.AddRange(new[] { id, nom, prenom });
    ///PRIMARY KEY (A COMMENTER SI PLUSIEURS ROWS A INSERER)
    table.PrimaryKey = new[] { id };

    ///INSTANCIE SQLDATAADAPTER SUR LA SQLCOMMAND ECRITE PLUS HAUT
    SqlDataAdapter adapter = new SqlDataAdapter(command);
    ///STOCKE DANS LA TABLE EN MEMOIRE
    ///POSSIBLE DE VERIFIER AVEC DEBUGGER + POINT D'ARRET
    adapter.Fill(table);*/

    ///4 - CREATE AND WRITE ROWS AVEC DATATABLES
    /*
    ///ECRIT UN ROW VIRTUEL
    table.Rows.Add(0, "LEPONGE", "Bob");
    ///SE SERT DE LA CLASSE SQLBULKCOPY POUR ECRIRE
    SqlBulkCopy copy = new SqlBulkCopy(connection);
    ///LUI INDIQUE LA TABLE DE DESTINATION
    copy.DestinationTableName = "Personnes";
    ///ECRIT
    copy.WriteToServer(table);*/

}
catch (System.Exception)
{
    throw;
}
finally
{
    ///TOUJOURS FERMER APRES USAGE
    connection.Close();
}


