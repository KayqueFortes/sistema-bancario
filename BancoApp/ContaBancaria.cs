namespace BancoApp;

public class ContaBancaria
{
    public decimal Saldo { get; private set; }

    public ContaBancaria(decimal saldoInicial)
    {
        Saldo = saldoInicial;
    }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor do depósito deve ser positivo.");

        Saldo += valor;
    }

    public void Sacar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor do saque deve ser positivo.");

        if (valor > Saldo)
            throw new InvalidOperationException("Saldo insuficiente.");

        Saldo -= valor;
    }

    public void Transferir(ContaBancaria destino, decimal valor)
    {
        if (destino == null)
            throw new ArgumentNullException(nameof(destino));

        Sacar(valor);
        destino.Depositar(valor);
    }
}
