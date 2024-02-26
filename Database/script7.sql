CREATE TABLE generi (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
CREATE TABLE console (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);

CREATE TABLE utenti (id_utente INTEGER PRIMARY KEY, nome TEXT , cognome TEXT , eta INTEGER);
CREATE TABLE videogiochi (id_videogioco INTEGER PRIMARY KEY, id_utente INTEGER, nome TEXT, anno INTEGER, voto INTEGER CHECK (voto >= 0), id_genere INTEGER,id_console INTEGER, FOREIGN KEY (id_utente) REFERENCES utenti(id),  FOREIGN KEY (id_console) REFERENCES console(id) FOREIGN KEY (id_genere) REFERENCES generi(id),  FOREIGN KEY (id_console) REFERENCES console(id));



INSERT INTO generi (nome) VALUES ('avventura');
INSERT INTO generi (nome) VALUES ('sparatutto');
INSERT INTO generi (nome) VALUES ('picchiaduro');
INSERT INTO generi (nome) VALUES ('giochi di ruolo');
INSERT INTO generi (nome) VALUES ('giochi platform');
INSERT INTO generi (nome) VALUES ('racing');
INSERT INTO generi (nome) VALUES ('giochi sportivi');

INSERT INTO console (nome) VALUES ('playstation 5');
INSERT INTO console (nome) VALUES ('nintendo switch');
INSERT INTO console (nome) VALUES ('pc');
INSERT INTO console (nome) VALUES ('xbox');
INSERT INTO console (nome) VALUES ('pc');
INSERT INTO console (nome) VALUES ('smartphone');

INSERT INTO videogiochi (id_utente, nome, anno, voto, id_genere, id_console) VALUES (1,'zelda tears of the kingdom', 2023, 10, 1, 2);
INSERT INTO videogiochi (id_utente, nome, anno, voto, id_genere, id_console) VALUES (1,'resident evil 4 remake', 2023, 9, 2, 3);
INSERT INTO videogiochi (id_utente, nome, anno, voto, id_genere, id_console) VALUES (2,'resident evil 4 remake', 2023, 9, 2, 3);          
INSERT INTO videogiochi (id_utente, nome, anno, voto, id_genere, id_console) VALUES (2,'rainbow six', 2015, 8, 2, 3); 
INSERT INTO videogiochi (id_utente, nome, anno, voto, id_genere, id_console) VALUES (3,'fortnite', 2023, 7, 2, 3); 

INSERT INTO utenti ( nome, cognome, eta) VALUES ( 'giada', 'adamo', 22);
INSERT INTO utenti ( nome, cognome, eta) VALUES ( 'giorgio', 'adamo', 20);
INSERT INTO utenti ( nome, cognome, eta) VALUES ( 'pinco', 'pallo', 15);

