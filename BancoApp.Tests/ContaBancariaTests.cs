using BancoApp;

namespace BancoApp.Tests;

public class ContaBancariaTests
{
    [Fact]
    public void Depositar_DeveAdicionarSaldo()
    {
        var conta = new ContaBancaria(100);

        conta.Depositar(50);

        Assert.Equal(150, conta.Saldo);
    }

    [Fact]
    public void Sacar_DeveRemoverSaldo()
    {
        var conta = new ContaBancaria(100);

        conta.Sacar(40);

        Assert.Equal(60, conta.Saldo);
    }

    [Fact]
    public void Sacar_ComSaldoInsuficiente_DeveLancarExcecao()
    {
        var conta = new ContaBancaria(100);

        Assert.Throws<InvalidOperationException>(() => conta.Sacar(200));
    }

    [Fact]
    public void Transferir_DeveMoverValorEntreContas()
    {
        var origem = new ContaBancaria(200);
        var destino = new ContaBancaria(100);

        origem.Transferir(destino, 50);

        Assert.Equal(999, origem.Saldo);
        Assert.Equal(150, destino.Saldo);
    }
}
