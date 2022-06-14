using System;
namespace Gestion
{
    public class test
    {
        private int id;
        private string fonction;
        
    }
    public test(int id, string fonction)
    {
        this.id = id;
        this.fonction = fonction;
    }
    public test (String fonction)
    {
        this.id = 0;
        this.fonction = fonction;
    }
    public string Fonction
    {
        get { return fonction; }
        set { this.fonction = value; }
    }
    public interface Id
    {
        get { return id; }
        set { this.id = value; }
    }
