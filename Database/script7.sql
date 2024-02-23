CREATE TABLE generi (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
CREATE TABLE console (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);

CREATE TABLE videogiochi (id_videogioco INTEGER PRIMARY KEY, nome TEXT UNIQUE, anno INTEGER, voto INTEGER CHECK (voto >= 0), id_genere INTEGER,id_console INTEGER, FOREIGN KEY (id_genere) REFERENCES generi(id),  FOREIGN KEY (id_console) REFERENCES console(id));
CREATE TABLE utenti (id INTEGER PRIMARY KEY, nome TEXT UNIQUE, cognome TEXT UNIQUE, eta INTEGER);
CREATE TABLE utenti_videoiochi (id_utente INTEGER PRIMARY KEY, id_videogioco INTEGER PRIMARY KEY);

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

INSERT INTO utenti_videogiochi (id_utente, id_videogioco) VALUES (1,1);
INSERT INTO utenti_videogiochi (id_utente, id_videogioco) VALUES (1,2);
INSERT INTO utenti_videogiochi (id_utente, id_videogioco) VALUES (2,1);

INSERT INTO videogiochi (id, nome, anno, voto, id_genere, id_console) VALUES (1,'zelda tears of the kingdom', 2023, 10, 1, 2);
INSERT INTO videogiochi (id, nome, anno, voto, id_genere, id_console) VALUES (2,'resident evil 4 remake', 2023, 9, 2, 3);
                        
INSERT INTO utenti (id, nome, cognome, eta) VALUES (1, 'giada', 'adamo', 22);
INSERT INTO utenti (id, nome, cognome, eta) VALUES (2, 'giorgio', 'adamo', 20);