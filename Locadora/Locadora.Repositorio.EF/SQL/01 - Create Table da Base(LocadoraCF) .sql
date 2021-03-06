﻿CREATE TABLE [dbo].[cliente] (
    [Id] [int] NOT NULL IDENTITY,
    [Nome] [nvarchar](250) NOT NULL,
    CONSTRAINT [PK_dbo.cliente] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[jogo] (
    [Id] [int] NOT NULL IDENTITY,
    [Nome] [nvarchar](250) NOT NULL,
    [Preco] [decimal](18, 2) NOT NULL,
    [Categoria] [int] NOT NULL,
    [Descricao] [nvarchar](1500) NOT NULL,
    [Selo] [int] NOT NULL,
    [Imagem] [nvarchar](200),
    [Video] [nvarchar](200),
    [ClienteLocacao] [int],
    CONSTRAINT [PK_dbo.jogo] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_ClienteLocacao] ON [dbo].[jogo]([ClienteLocacao])
CREATE INDEX [IX_Selo] ON [dbo].[jogo]([Selo])
CREATE INDEX [IX_Categoria] ON [dbo].[jogo]([Categoria])
CREATE TABLE [dbo].[selo] (
    [Id] [int] NOT NULL,
    [Nome] [nvarchar](50) NOT NULL,
    CONSTRAINT [PK_dbo.selo] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[categoria] (
    [Id] [int] NOT NULL,
    [Nome] [nvarchar](50) NOT NULL,
    CONSTRAINT [PK_dbo.categoria] PRIMARY KEY ([Id])
)
ALTER TABLE [dbo].[jogo] ADD CONSTRAINT [FK_dbo.jogo_dbo.cliente_ClienteLocacao] FOREIGN KEY ([ClienteLocacao]) REFERENCES [dbo].[cliente] ([Id])
ALTER TABLE [dbo].[jogo] ADD CONSTRAINT [FK_dbo.jogo_dbo.selo_Selo] FOREIGN KEY ([Selo]) REFERENCES [dbo].[selo] ([Id])
ALTER TABLE [dbo].[jogo] ADD CONSTRAINT [FK_dbo.jogo_dbo.categoria_Categoria] FOREIGN KEY ([Categoria]) REFERENCES [dbo].[categoria] ([Id])
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201511100208570_Initial', N'Locadora.Repositorio.EF.Migrations.Configuration',  0x1F8B0800000000000400ED5ADB6EDB3618BE1FB07710743964560E2BD005768BD4760A6F496CD849B0BB82917E3BDC285223A920DEB027DBC51E69AFB05F4753942CCB49DAECA2E84D42FDFCF89F4FE9BF7FFFD37FFF1832E701A4A2820FDCA3DEA1EB00F74540F96AE0C67AF9FD5BF7FDBB6FBFE98F83F0D1B92DE84E123ABCC9D5C0BDD73A3AF53CE5DF4348542FA4BE144A2C75CF17A14702E11D1F1EFEE81D1D7980102E62394E7F1E734D43487FC15F8782FB10E998B04B110053F9397E59A4A8CE15094145C487817B217C0495A437874828AA85A4A2373E779D334609B2B300B6741DC2B9D04423B3A7370A165A0ABE5A447840D8F53A02A45B12A62017E27443DE559EC3E3441E6F73B180F263A545B827E0D149AE20CFBEFE2435BBA50251856354B55E2752A76A1CB84346816B94DD7EEB74C864426728792442CA51C1F99D03C7FE72503A05FA4EF2EFC019C64CC712061C622D093B7066F11DA3FECFB0BE16BF011FF098319343E411BF550EF06826450452AFE7B0CCF99E04AEE355EF79F6C5F29A71271369C2F5C9B1EB5CE1E3E48E41E90086F80B7426F8081C24D110CC88D620798201A90A6BAF5B6F5D89108AD7D0E330825CE7923C5E005FE9FB817BFC0663E69C3E42509CE41CDC708A018797B48CA18143F3D5BEB73167AB917F122BB19785930B5FCDFBCAE6ADBF3A93E08BE2D911F83424CC7592539AA7ECB7AEB3F04902D8247F3BFA1035B1C20C4A4AC1307BF68CD33DF146A07C497D225A1475F4E6F0B3680A59171531B2833D5126215941D866E78EDCB73F734B036853D2135FB9220F74957ABB6DE82C7F27E19D5A670E2C2553F734CAD59524804F36DDB914E15CB03CA1589F3F2D442CFD2428C4769A6B2257A0BB66B138340BD5C60F27EA9C91D5A66CEF53BA0A9497CB6E688500245BA3D5CCEC53B5C5258477207351E6B38FAE734B588C3F1FD5CC56211D4EE7F3C9E8AC243F6E273FBB1D5F5DDFCC37F427EDF41737D71BDA1FDA69C78BD9747E3D2EC9DFD4CD9819ACC58859143EC37E09C06B9AEE03F68E7F4057EBCDB0B890AEB69BC6526CB35BB372CF94123E4D5566147A3B6CAB4F8E79E0EC8E4F33FF170DE2256A9446A8438CD5817BD8EBD5856F072F13C4063C6B4C7621F73D43D27AA383038326946F6C44148C60841EA21A7C0B2780DCBD549E376D1912CC0568BB41DE64295B33352D541132216BD7B363EBAE216815A0968C0DCA969C6D775ADDCC5F4A6088EFED075518DB806A14D8AB4ADC50174AF36E06412F9B048B89D1DB3232F62F4914616C1B23647EE22CB2F971F8FD62FF992ACC303C5F358C5625B7E54BD8686217617DC5A791D3732A951E618EB823491E1C06618DCC74E62D6E56BC54F5D7BAB90AFF2BE8939FF332D03C46F7B6606DF4788EA28548924A090D6E53BB998EF18411D9D0BC0F058B43BE6D0068BB9DB5E3E6FDECA48ED0F72CD66D3D793545590E6BEBBD935552DF7F0993340175B047F3B5D736C636847CCE3121F2A3EE1846BF68E218C7DDB18C49C6C4328EBB63652D9009939D744728A6928A85F2B3EE28F9D06182E4475F3E68AA35A01E39B5E2D72D4E6AD7BA444552D72C55B594CABAAA3A0594CD58ADB87A06174F63302FC04F64B029E25B99C29215D0B4139DA864CA2E9BFBEE62DBBD40DD556A2D814D523A6AD91A582D403F2FC7BB57CBB5FA9C9124EB16F1808182B579B1561AC25E42D05BFCCE32E936049784D325289D0D1C38C51F1D5B8BE9FFCF92D8532A60DD36C55F7C9B4713A5EEDCD7EDB9DA311778FC8148FF9EC8FA0AEF05D7AF5FD5B615B4B2D60C3EFB5A3355CC7377998DC267DBCC67AC2A9FC25A7549D96C942A5B7BEF245F0AB4A98CE742D7E6F4090FE071E0FE995E3D7526BF5805EEC0994A4CB2A7CEA1F3573B1FDBE2F479EB9372307E915DC9CEADC8773500CC13209330260CEBA1D2122B62AD319B49CA7D1A1166715D6F0BBAA49F449725A2FD650411F024AF9862757967773354425BC970970AF65C1CD547F267AF86B2A601B3DA5D62E2CC43FD97D81B3501FFFABA1B254B1D7BAD8FBED0A2A8DEFDA11319FFFD009D58D1D50622696B39F815F72969267C290A6FB6382A48ACFC77099A04E85B6752D325F1357EF641A9F4EF3DF9E2771CDE4130E1D35847B1469121BC6395BF4626D1D0F67EBA0DABF2DC9F46E99F775E42046493A20830E51F62CA8292EFF386FE680B441266794B92D85227ADC96A5D225D09DE1128575F991DAE218C1882A9295F9007780A6F370A2E6045FC75D1C46F07D96D88AADAFB234A5692842AC7D8DCC75FD18783F0F1DD7F0094B51185230000 , N'6.1.3-40302')

