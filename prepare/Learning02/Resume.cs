using System;
using System.Collections.Generic;

public class Resume
{
    // Variables miembro que almacenan el nombre y la lista de trabajos
    public string _name;
    public List<Job> _jobs = new List<Job>();

    // Método para mostrar los detalles del currículum
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        
        // Llamar al método Display de cada trabajo en la lista
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}
