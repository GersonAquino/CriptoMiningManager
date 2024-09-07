CREATE TABLE Mineradores (
	Id INTEGER PRIMARY KEY AUTOINCREMENT,
	IdMoeda INTEGER NULL,

	Nome NVARCHAR (200) NULL,
	Localizacao NVARCHAR (4000) NOT NULL,

	CPU BIT NOT NULL DEFAULT 0, --Utiliza o CPU
	GPU BIT NOT NULL DEFAULT 0, --Utiliza a GPU
	ConsumoMedio DECIMAL(10, 5) NULL,

	Parametros NVARCHAR (4000) NULL,
	Ativo BIT NOT NULL DEFAULT 0,
	
	DataCriacao DateTime NOT NULL,
	DataAlteracao DateTime NOT NULL,
	
	FOREIGN KEY (IdMoeda) REFERENCES Moedas (Id)
);

CREATE TABLE Comandos (
	Id INTEGER PRIMARY KEY AUTOINCREMENT,
	Comandos NVARCHAR (4000) NOT NULL,
	
	PreMineracao BIT NOT NULL DEFAULT 0,
	PosMineracao BIT NOT NULL DEFAULT 0,
	
	Ativo BIT NOT NULL DEFAULT 0,
	
	DataCriacao DateTime NOT NULL,
	DataAlteracao DateTime NOT NULL
);

CREATE TABLE Moedas (
	Id INTEGER PRIMARY KEY AUTOINCREMENT,
	IdExterno INTEGER NULL,
	
	Nome NVARCHAR (500) NULL,
	NomeExterno NVARCHAR (500) NULL,
	
	DataCriacao DateTime NOT NULL,
	DataAlteracao DateTime NOT NULL
);

CREATE TABLE ConfiguracoesGerais (
	Id INTEGER PRIMARY KEY AUTOINCREMENT,
	Descricao NVARCHAR (200) NOT NULL,
	
	AtualizarUIMinimizado BIT NOT NULL DEFAULT 0,
	ConfirmacoesExtraNosEditores BIT NOT NULL DEFAULT 0,
	IniciarMinimizada BIT NOT NULL DEFAULT 0,
	MinimizarAoFechar BIT NOT NULL DEFAULT 0,

	MedirConsumo BIT NOT NULL DEFAULT 0,
	PesoConsumo INTEGER NOT NULL DEFAULT 0, --Em Watts

	AlgoritmoPorDefeito NVARCHAR(100) NULL,

	AlternarModoEnergia BIT NOT NULL DEFAULT(0),

	LocalizacaoLogsMineracao NVARCHAR(512) NULL,

	Ativo BIT NOT NULL DEFAULT 0,
	
	DataCriacao DateTime NOT NULL, --DEFAULT CURRENT_TIMESTAMP //Isto dá o tempo GMT, não é o tempo local, portanto não serve (ex: fica 1h atrasado no horário de Verão)
	DataAlteracao DateTime NOT NULL
);

--CREATE TABLE Mineradores_Moedas (
--	IdMinerador INTEGER,
--	IdMoeda INTEGER,

--	PRIMARY KEY (IdMinerador, IdMoeda),
--	FOREIGN KEY (IdMinerador) REFERENCES Mineradores(Id),
--	FOREIGN KEY (IdMoeda) REFERENCES Moedas(Id)
--);