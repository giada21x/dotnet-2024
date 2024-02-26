# Database

### Comandi

1. .open 'nome del file da aprire.db'  esempio: .open database.db
2. CREATE TABLE 'nome della tabella' ('nome colonna''TIPO', 'nome colonna''TIPO', 'nome colonna''TIPO'); 
esempio: CREATE TABLE prodotti (nome TEXT, prezzo REAL, quantita INTEGER);

3. crea manualmente un file script.sql in cui inserire i valori 
(puoi evitare di usare il comando 2 inserendolo direttamente inl file script.sql 
CREATE TABLE prodotti (nome TEXT, prezzo REAL, quantita INTEGER);)
INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p1', 1, 10);
INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p2', 2, 20);
INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p3', 3, 30);

4. .read 'nome del file script.sql' esempio: .read script.sql
5. SELECT * FROM 'nome della tabella'; serve per visionare la tabella nel terminale (ma sottoforma di lista)
esempio: SELECT * FROM prodotti;
6. .mode table visionare la tabella sottoforma di vera e propria tabella
7. INSERT INTO 'nome della tabella' VALUES ('valore nome', 'valore prezzo', 'valore quantita');
esempio: INSERT INTO prodotti VALUES ('p4', '4', '40');
8. SELECT * FROM prodotti ORDER BY quantita DESC; visualizza la tabella nel terminale partendo però dal basso verso l'alto
9. SELECT * FROM prodotti WHERE nome = 'p1'; visualizza solo il nome 'p1' nella tabella
10. DELETE FORM prodotti WHERE nome = 'p1'; cancella solo il nome 'p1' nella tabella
11. creo un'altra tabella e la chiamo categoria
CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (quantita >= 0), id_categoria INTEGER, FOREIGN KEY (id_categoria) REFERENCES categorie(id));
INSERT INTO categorie (nome) VALUES ('c1');
INSERT INTO categorie (nome) VALUES ('c2');
INSERT INTO categorie (nome) VALUES ('c3');
INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('p1', 1, 10, 1);
INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('p2', 2, 20, 2);
INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('p3', 3, 30, 3);
12. UPDATE prodotti SET nome = 'culetto'  WHERE nome = 'p1';
13. SELECT videogiochi.nome, videogiochi.anno, videogiochi.voto, generi.nome AS genere, console.nome AS console FROM videogiochi JOIN generi ON id_genere = generi.id JOIN console ON id_console = console.id;

SELECT utenti.id_utente, utenti.nome, utenti.cognome, videogiochi.nome, videogiochi.voto FROM utenti JOIN videogiochi ON utenti.id_utente = videogiochi.id_utente;