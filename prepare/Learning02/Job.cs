public class Job
{
    // Variables miembro que almacenan los detalles del trabajo
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    // Método para mostrar los detalles del trabajo en el formato requerido
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}
