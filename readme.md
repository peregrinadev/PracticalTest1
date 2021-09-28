# Teste Pr�tico .NET - Refatora��o

**Introdu��o:**

O teste pr�tico .NET � um exerc�cio para estender a funcionalidade de uma solu��o existente.

**O teste � avaliado em: **

1. Programa��o orientada a objeto (OOP)
2. Facilidade de leitura (readability)
3. Manutenabilidade
4. Testabilidade
5. Extensibilidade

**Dicas:**

- Reserve um tempo para percorrer a funcionalidade existente ANTES de tentar fazer altera��es
- Sinta-se � vontade para adicionar pacotes de terceiros (Nuget) conforme necess�rio

**Requisitos t�cnicos:**

A solu��o deve:
- Compilar sem erros
- Executar a partir da linha de comando
- Passar em todos os casos de teste automatizados

**Requisitos funcionais:**

1. Adicionar a capacidade de alternar entre manh� e noite e fazer com que seja o primeiro par�metro necess�rio (� "case insensitive", portanto n�o diferencia mai�sculas de min�sculas)
2. Adicionar a capacidade de ter pratos diferentes de manh� e � noite (veja o exemplo de entrada/sa�da abaixo)
3. Voc� pode ter v�rios pedidos de caf� pela manh� (mas ainda n�o mais do que 1 de cada um dos outros "Tipo de Prato")
4. A sobremesa n�o est� dispon�vel como um "Tipo de Prato" matinal
5. Preserve os requisitos existentes:
    - Voc� deve inserir uma lista delimitada por v�rgulas de "Tipo de Prato" com pelo menos uma sele��o
    - A sa�da deve imprimir os nomes dos pratos na seguinte ordem: entrada, acompanhamento, bebida, sobremesa
    - Se uma sele��o inv�lida for encontrada, imprima "error"
    - Ignore os espa�os em branco na entrada
    - Cada tipo de prato � opcional (ou seja, pode ter 0 se n�o for inserido na entrada)
    - Voc� pode ter v�rios pedidos de batatas (mas ainda n�o mais do que 1 de cada um dos outros Tipos de Prato)
    - Se mais de um Tipo de Prato for inserido, imprima uma vez, seguido por "(xN)", por exemplo, "batata(x2)"

**Pratos do per�odo da NOITE**

| **Tipo do Prato** | **Nome do Prato** |
| -------------     | -------------     |
| 1 (entrada)       | carne             |
| 2 (acompanhamento)| batata            |
| 3 (bebida)        | vinho             |
| 4 (sobremesa)     | bolo              |

**Pratos do per�odo da MANH�**

| **Tipo do Prato** | **Nome do Prato** |
| -------------     | -------------     |
| 1 (entrada)       | ovos              |
| 2 (acompanhamento)| torrada           |
| 3 (bebida)        | caf�              |






**Exemplos de entrada e sa�da (atualmente)**

| **Entrada**       | **Sa�da** |
| -------------     | -------------     |
| 1,2,3,4           | carne,batata,vinho,bolo   |
| 4,2,2,1           | carne,batata(x2),bolo   |
| 1,2,3,5           | error   |
| 1,3,2,3           | error   |






**Exemplos de entrada e sa�da (como dever� ficar)**

| **Entrada**               | **Sa�da** |
| -------------             | -------------     |
|manh�, 1, 2, 3             | ovos,torrada,caf�   |
|Manh�,3,3,3                | caf�(x3)   |
|manh� ,1,3,2,3             | ovos,torrada,caf�(x2)   |
|manh�, 1, 2, 2             | error   |
|manh�, 1, 2, 4             | error   |
|noite,1, 2, 3, 4           | carne,batata,vinho,bolo   |
|Noite,1, 2, 2, 4           | carne,batata(x2),bolo   |
|noite,1, 2, 3, 5           | error   |
|noite,1, 3, 2, 3           | error   |
