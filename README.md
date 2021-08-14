Rodar testes:
--collect:"XPlat Code Coverage"

Criar relatorio de cobertura:
reportgenerator -reports:"..\tests\TesteXP.Test\TestResults\{guid}\coverage.cobertura.xml" -targetdir:"..\tests\coveragereport" -reporttypes:Html