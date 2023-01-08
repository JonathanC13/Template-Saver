use jon; return;

CREATE TABLE[tblButtonAttribute](
[nRecID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [lngButtonID] INTEGER NOT NULL
, [strHotKeyLabel] TEXT NOT NULL
, [strHotKeyDesc] TEXT NOT NULL
, [nDescHeight] bigint NOT NULL
, [nColorR] bigint NOT NULL
, [nColorG] bigint NOT NULL
, [nColorB] bigint NOT NULL
);



CREATE TABLE [relTemplateButtonAttribute] (" +
"  [nRecID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL" +
", [nTemplateID] bigint NOT NULL" +
", [nButtonID] bigint NOT NULL" +
", CONSTRAINT FK_nTemplateID FOREIGN KEY(nTemplateID) REFERENCES tblTemplate(nTemplateID)" +
", CONSTRAINT FK_nButtonID FOREIGN KEY(nButtonID) REFERENCES tblButtonAttribute(nButtonID)" +
"); 