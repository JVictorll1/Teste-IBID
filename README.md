# Teste-IBID
Teste de Cohecimento da empresa IBID Informática.

INÍCIO RÁPIDO:

1 - Baixe o Repositório em sua máquina local;

2 - Dentro da pasta do projeto, existe um arquivo do tipo '.sql' chamado 'script-BDCADASTRO'. 
Ele contém o script necessário para a criação do banco de dados e da tabela necessários para o uso do app.

3 - Abra o script mencionado anteriormente no SSMS do SQL Server. Execute os scripts na sequência que se encontram da mesma forma que está lá.

4 - Depois disso, no código fonte do projeto, mas p´recisamente na Classe 'Conexao.cs', se encontra o atributo do tipo string 
chamado 'connectionString', onde nele está escrito 'Codart'. Esse é o nome da minha conexão local. Altere esse nome para o da sua 
própria conexão do SQL Server onde se encontra o Banco de Dados criado com o script mencionado anteriormente.

5 - No seu Terminal, você deve estar dentro do mesmo diretório onde se encontra o arquivo 'Program.cs'.

6 - Agora basta compilar o App com o comando 'dotnet run', onde será compilado e executado o App normalmente. 
Caso esteja utilizando o Sistema Operacional 'Windows', basta compilar com o comando 'dotnet build' e acessar
o seguinte caminho até o executável:

    ConsoleApp-CRUD > bin > Debug > net6.0 > ConsoleApp-CRUD.exe

7 - O software possui uma interface simples do tipo Console Application.

8 - Bom Aprendizado!
