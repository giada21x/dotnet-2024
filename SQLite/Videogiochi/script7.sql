    --------------CREAZIONE TABELLA GENERI--------------
CREATE TABLE generi (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
    
    --------------CREAZIONE TABELLA CONSOLE--------------
CREATE TABLE console (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
    
    --------------CREAZIONE TABELLA UTENTI--------------
CREATE TABLE utenti (id_utente INTEGER PRIMARY KEY, nome TEXT , cognome TEXT , eta INTEGER);
    
    --------------CREAZIONE TABELLA VIDEOGIOCHI--------------
CREATE TABLE videogiochi (id_videogioco INTEGER PRIMARY KEY, id_utente INTEGER, nome TEXT, anno INTEGER, voto INTEGER CHECK (voto >= 0), id_genere INTEGER,id_console INTEGER, FOREIGN KEY (id_utente) REFERENCES utenti(id),  FOREIGN KEY (id_console) REFERENCES console(id) FOREIGN KEY (id_genere) REFERENCES generi(id),  FOREIGN KEY (id_console) REFERENCES console(id));


    --------------INSERIMENTO DATI TABELLA GENERI--------------
INSERT INTO generi (nome) VALUES ('avventura');
INSERT INTO generi (nome) VALUES ('sparatutto');
INSERT INTO generi (nome) VALUES ('picchiaduro');
INSERT INTO generi (nome) VALUES ('giochi di ruolo');
INSERT INTO generi (nome) VALUES ('giochi platform');
INSERT INTO generi (nome) VALUES ('racing');
INSERT INTO generi (nome) VALUES ('giochi sportivi');

    --------------INSERIMENTO DATI TABELLA CONSOLE--------------
INSERT INTO console (nome) VALUES ('playstation 5');
INSERT INTO console (nome) VALUES ('nintendo switch');
INSERT INTO console (nome) VALUES ('pc');
INSERT INTO console (nome) VALUES ('xbox');
INSERT INTO console (nome) VALUES ('pc');
INSERT INTO console (nome) VALUES ('smartphone');

    --------------INSERIMENTO DATI TABELLA VIDEOGIOCHI--------------
INSERT INTO videogiochi (id_utente, nome, anno, voto, id_genere, id_console) VALUES (1,'zelda tears of the kingdom', 2023, 10, 1, 2);
INSERT INTO videogiochi (id_utente, nome, anno, voto, id_genere, id_console) VALUES (1,'resident evil 4 remake', 2023, 9, 2, 3);
INSERT INTO videogiochi (id_utente, nome, anno, voto, id_genere, id_console) VALUES (2,'resident evil 4 remake', 2023, 9, 2, 3);          
INSERT INTO videogiochi (id_utente, nome, anno, voto, id_genere, id_console) VALUES (2,'rainbow six', 2015, 8, 2, 3); 
INSERT INTO videogiochi (id_utente, nome, anno, voto, id_genere, id_console) VALUES (3,'fortnite', 2023, 7, 2, 3); 

    --------------INSERIMENTO DATI TABELLA UTENTI--------------
INSERT INTO utenti ( nome, cognome, eta) VALUES ( 'giada', 'adamo', 22);
INSERT INTO utenti ( nome, cognome, eta) VALUES ( 'giorgio', 'adamo', 20);
INSERT INTO utenti ( nome, cognome, eta) VALUES ( 'pinco', 'pallo', 15);

    
    --------------JOIN--------------
SELECT videogiochi.nome, videogiochi.anno, videogiochi.voto, generi.nome AS genere, console.nome AS console FROM videogiochi JOIN generi ON id_genere = generi.id JOIN console ON id_console = console.id;

SELECT utenti.id_utente, utenti.nome, utenti.cognome, videogiochi.nome, videogiochi.voto FROM utenti JOIN videogiochi ON utenti.id_utente = videogiochi.id_utente;

SELECT utenti.id_utente, utenti.nome, utenti.cognome, videogiochi.nome, generi.nome, console.nome, videogiochi.voto FROM utenti JOIN videogiochi ON utenti.id_utente = videogiochi.id_utente JOIN generi ON id_genere = generi.id JOIN console ON id_console = console.id