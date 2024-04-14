//Screen Sound
string mensagemDeBoasVindas = "Boas vindas ao Scren Sound";
//List<string> listaDeBandas = new List<string> { "U2", "The Beatles", "Iron Maden"};

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 8, 6 });
bandasRegistradas.Add("The Beatles", new List<int>());


//Declarando uma função 
void ExibirLogo() //Nomes de Funçoes em Pascal Case, ou seja, o nome da Variavel deve sempre iniciar com letra maiuscula.
{
    // Utilizando Verbatim Literal, ele exibe a sting da forma que ela esta sendo colocada ignorando alguns aspectos como quebras.
    Console.WriteLine(@"

█████████████████████████████████████████████████████████████████████████
█─▄▄▄▄█─▄▄▄─█▄─▄▄▀█▄─▄▄─█▄─▄▄─█▄─▀█▄─▄███─▄▄▄▄█─▄▄─█▄─██─▄█▄─▀█▄─▄█▄─▄▄▀█
█▄▄▄▄─█─███▀██─▄─▄██─▄█▀██─▄█▀██─█▄▀─████▄▄▄▄─█─██─██─██─███─█▄▀─███─██─█
▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▄▀▀▄▄▀▀▀▄▄▄▄▄▀▄▄▄▄▀▀▄▄▄▄▀▀▄▄▄▀▀▄▄▀▄▄▄▄▀▀
");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda"); //Coloquei um "\n" para ele pular uma linha antede de exibir a linnha quie contem o "\n"
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a media de uma banda");
    Console.WriteLine("Digite -1 para sair ");

    Console.Write("\nDigite a sua opção: ");//Aqui foi utilizado somente o Write ao invez do WriteLine, pois dessa forma ele nao pula linha apos exibir o texto.
    string opcaoEscolhida = Console.ReadLine()!;//Nofinal eu coloco uma exclamação informando que esse retorno precisa ser uma string
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);//Função Parse esta pegando uma string e convertendo para inteiro.
   
    switch (opcaoEscolhidaNumerica)

    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarUmaBanda();
            break;
        case 4: ExibirMediaDaBanda();

            break;
        case -1: Console.WriteLine("Tchal :)");
            break;
        default: Console.WriteLine("Opção invalida");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das bandas");
    Console.Write("\nDigite o Nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso"); //Interpolação de String, permite exibir o valor de uma variavel dentro de um texto, colocando "$" antes de iniciar a string, e colocando a variavel entr chaves "{}"
    Thread.Sleep(2000);
    Console.Clear() ;
    ExibirOpcoesDoMenu();
}
void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as listaDeBandas registradas");
    //for(int i = 0; i< listaDeBandas.Count; i++)
    //{
    //Console.WriteLine($"Banda: {listaDeBandas[i]}");
    //}
    foreach(string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nDigite uma tecla para voltar par ao Menu Principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo) {

    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

//Chamndo a função declarada a cima
ExibirOpcoesDoMenu();

void AvaliarUmaBanda()
{
    //digitar qual banda deseja avaliar
    //buscar a banda no dicionario, se a banda existir >> atribuir uma nota
    //se nao exibir, exibe uma mensagem e volta ao menu principal

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Banda");
    Console.Write("Digite o nome da banda que deseja Avaliar:  ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine($"Qual nota a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}!"); 
        Thread.Sleep(3000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.Write($"\nA banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("Digite qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}
void ExibirMediaDaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir media da Banda");
    Console.WriteLine("Digite o nome da banda que voce deseja ver a media de notas: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notas = bandasRegistradas[nomeDaBanda];
        
        //Somando a quantidade de notas que a banda escolhida tem
        int quantidadeDeNotas = notas.Count;

        //Soma de todas as notas que essa banda tem

        int somaDasNotas = 0;

        foreach (int nota in notas)
        {
            somaDasNotas += nota;
        }

        //Divisão da soma pela quantidade para obter a media

        int media = somaDasNotas / notas.Count;

        //Exibindo no console a Média

        Console.WriteLine($"A media das nostas da banda {nomeDaBanda} é de {media}!");

        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();

        }
    else
    {
        Console.Write($"\nA banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

