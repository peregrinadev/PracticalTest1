# Teste Prático .NET - Refatoração

**Introdução:**

O teste prático .NET é um exercício para estender a funcionalidade de uma solução existente.

** O teste é avaliado em: **

1. Programação orientada a objeto (OOP)
2. Facilidade de leitura (readability)
3. Manutenabilidade
4. Testabilidade
5. Extensibilidade

**Dicas:**

- Reserve um tempo para percorrer a funcionalidade existente ANTES de tentar fazer alterações
- Sinta-se à vontade para adicionar pacotes de terceiros (Nuget) conforme necessário

**Requisitos técnicos:**

A solução deve:
- Compilar sem erros
- Executar a partir da linha de comando
- Passar em todos os casos de teste automatizados

**Requisitos funcionais:**

1. Adicionar a capacidade de alternar entre manhã e noite e fazer com que seja o primeiro parâmetro necessário (é "case insensitive", portanto não diferencia maiúsculas de minúsculas)
2. Adicionar a capacidade de ter pratos diferentes de manhã e à noite (veja o exemplo de entrada/saída abaixo)
3. Você pode ter vários pedidos de café pela manhã (mas ainda não mais do que 1 de cada um dos outros "Tipo de Prato")
4. A sobremesa não está disponível como um "Tipo de Prato" matinal
5. Preserve os requisitos existentes:
    - Você deve inserir uma lista delimitada por vírgulas de "Tipo de Prato" com pelo menos uma seleção
    - A saída deve imprimir os nomes dos pratos na seguinte ordem: entrada, acompanhamento, bebida, sobremesa
    - Se uma seleção inválida for encontrada, imprima "error"
    - Ignore os espaços em branco na entrada
    - Cada tipo de prato é opcional (ou seja, pode ter 0 se não for inserido na entrada)
    - Você pode ter vários pedidos de batatas (mas ainda não mais do que 1 de cada um dos outros Tipos de Prato)
    - Se mais de um Tipo de Prato for inserido, imprima uma vez, seguido por "(xN)", por exemplo, "batata(x2)"

**Pratos do período da noite**

| **Tipo do Prato** | **Nome do Prato** |
| -------------     | -------------     |
| 1 (entrada)       | carne             |
| 2 (acompanhamento)| batata            |
| 3 (bebida)        | vinho             |
| 4 (sobremesa)     | bolo              |

**Pratos do período da manhã**

| **Tipo do Prato** | **Nome do Prato** |
| -------------     | -------------     |
| 1 (entrada)       | ovos              |
| 2 (acompanhamento)| torrada           |
| 3 (bebida)        | café              |


**Exemplos de entrada e saída (atualmente)**

1,2,3,4   =>   carne,batata,vinho,bolo 
4,2,2,1   =>   carne,batata(x2),bolo 
1,2,3,5   =>   error 
1,3,2,3   =>   error 

**Exemplos de entrada e saída (como deverá ficar)**

manhã, 1, 2, 3     =>   ovos,torrada,café
Manhã,3,3,3        =>   café(x3)
manhã ,1,3,2,3     =>   ovos,torrada,café(x2)
manhã, 1, 2, 2     =>   error
manhã, 1, 2, 4     =>   error
noite,1, 2, 3, 4   =>   carne,batata,vinho,bolo
Noite,1, 2, 2, 4   =>   carne,batata(x2),bolo
noite,1, 2, 3, 5   =>   error
noite,1, 3, 2, 3   =>   error
