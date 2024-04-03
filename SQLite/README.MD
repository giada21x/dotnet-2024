# DATABASE RELAZIONALI
I database relazionali sono un tipo di database che utilizzano il modello relazionale, ovvero un modello di dati basato sul concetto matematico di relazione. 

# SQLITE
è un linguaggio standardizzato per database.

### INSTALLAZIONE SQLITE

- Per poterlo utilizzare è necessario installare il pacchetto attraverso il seguente il comando:

> dotnet add package System.Data.SQLite

- Inoltre se vogliamo utilizzare il tool sqlite3 per visualizzare il contenuto del databse è necessario installare ilpacchetto sqlite3 attravers oil seguente comando: 

> dotnet tool install --global dotnet-sqlite

- Su windows bisogna impostare la variabile d'ambiente PATH con il percorso della cartella bin di sqlite3.
Per farlo Pannello di controllo > Sistema e sicurezza > Sistema > Impostazioni di sistema avanzate > Variabili d'ambiente e aggiungere il percorso della cartella bin di sqlite3 alla variabile PATH.
Ad esempio, se sqlite3 è installato in C:\sqlite3 aggiungere C:\sqlite3\bin alla variabile PATH.

- è necessario installare anche l'estensione per poter visualizzare adeguatamente i databse su vsc: Sqlite Viewer

## INIZIALIZZARE SQLITE TRAMITE TERMINALE (SENZA SCRIPT)

1. Accedi alle funzionalità di sqlite

> sqlite3 

2. Crea il database

> .open 'nome del database.db'

3. Crea la tabella 

> CREATE TABLE 'nome della tabella' ('nome colonna''TIPO', 'nome colonna''TIPO', 'nome colonna''TIPO');

Esempio: 

> CREATE TABLE prodotti (nome TEXT, prezzo REAL, quantita INTEGER);

4. Inserisci i dati all'interno della tabella

> INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p1', 1, 10);

## INIZIALIZZARE SQLITE TRAMITE LO SCRIPT

1. Crea manualmente un file denominato script.sql

2. inserisci nel file i comandi che ti servono per creare la tabella e per inserire i dati all'interno della tabella

> CREATE TABLE prodotti (nome TEXT, prezzo REAL, quantita INTEGER);

> INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p1', 1, 10);

> INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p2', 2, 20);

> INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p3', 3, 30);

3. usa il comando per inizializzare ciò che hai scritto nella quary

> .read 'nome del file script.sql' 

## COMANDI GENERALI

Prendiamo come esempio questaa tabella prodotti:

CREATE TABLE prodotti (nome TEXT, prezzo REAL, quantita INTEGER);
INSERT INTO prodotti VALUES ('p1', 1, 10);
INSERT INTO prodotti VALUES ('p2', 2, 20);
INSERT INTO prodotti VALUES ('p3', 3, 30);

| nome | prezzo | quantità |
|------|--------|----------|
| p1   | 1      | 10       |
| p2   | 2      | 20       |
| p3   | 3      | 30       |

-  Visualizzare il contenuto del tabella nel terminale (ma sottoforma di lista)

> SELECT * FROM prodotti; 

- Visualizzare il database sottoforma di vera e propria tabella

> .mode table 

- Visualizzare la tabella nel terminale ordinato per prezzo (è possibile utilizzare gli attributi ASC e DESC per l'ordinamento)

> SELECT * FROM prodotti ORDER BY prezzo 

- Modificare un valore in particolare : modificare il prezzo del prodotto con nome p1 in 10

> UPDATE prodotti SET prezzo = 10 WHERE nome = 'p1';

- Eliminare un elemento dalla lista : eliminare un prodotto

> DELETE FROM prodotti WHERE nome = 'p2';

- Visualizzare un elemento della tabella in particolare: visualizzare il prodotto p1

> SELECT * FROM prodotti WHERE nome = 'p1';

- Visualizzare i prodotto più costoso

> SELECT * FROM prodotti ORDER BY prezzo DESC LIMIT 1;

- Visualizzare il prodotto meno costoso

> SELECT * FROM prodotti ORDER BY prezzo ASC LIMIT 1;

- Creare un database di prodotti con id autoincrement e nome univoco e quantità non negativa

> CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (quantita >= 0));

> INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p1', 1, 10);

> INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p2', 2, 20);

> INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p3', 3, 30);

- Collegare due tabelle 

CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (quantita >= 0), id_categoria INTEGER, FOREIGN KEY (id_categoria) REFERENCES categorie(id));
INSERT INTO categorie (nome) VALUES ('c1');
INSERT INTO categorie (nome) VALUES ('c2');
INSERT INTO categorie (nome) VALUES ('c3');
INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('p1', 1, 10, 1);
INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('p2', 2, 20, 2);
INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('p3', 3, 30, 3);

| id | nome | prezzo | quantità | id_categoria |
|----|------|--------|----------|--------------|
| 1  | p1   | 1      | 10       | 1            |
| 2  | p2   | 2      | 20       | 2            |
| 3  | p3   | 3      | 30       | 3            |

| id | nome |
|----|------|
| 1  | c1   |
| 2  | c2   |
| 3  | c3   |

> SELECT * FROM prodotti JOIN categorie ON prodotti.id_categoria = categorie.id;

oppure si possono visualizzare i dati solo di alcune colonne con il comando:

> SELECT prodotti.nome, prodotti.prezzo, prodotti.quantita, categorie.nome FROM prodotti JOIN categorie ON prodotti.id_categoria = categorie.id;



