using System.Data.SqlClient;
using MySql.Data.MySqlClient;

public static class Connexion
{
    public static MySqlConnection GetConnexion()
    {
        string connexionString = "server=localhost;database=habilitations2024;uid=root;pwd=EK7_stesteve;";
        return new MySqlConnection(connexionString);
    }
}
