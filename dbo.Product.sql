CREATE TABLE [dbo].[Product] (
    [ProdId]    INT        NOT NULL,
    [ProdName]  VARCHAR (20) NOT NULL,
    [ProdPrice] INT        NOT NULL,
    [ProdQty]   INT        NOT NULL,
    [ProdCat]   VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([ProdId] ASC)
);

