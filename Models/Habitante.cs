namespace exercise.Models
{
  public class Habitante
  {
    public long HabitanteId { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataDeNascimento { get; set; }
    public float Renda { get; set; }
    public string CPF { get; set; }
  }
}