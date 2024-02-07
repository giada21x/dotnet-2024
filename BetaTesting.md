# GIOCO INDOVINA IL NUMERO

Programma che permette all'utente di provare a indovinare un numero randomico (tra 1 e 50) sorteggiato dal computer. L'utente ha a diposizione 10 tentativi per poter indovinare il numero segreto. Inoltre ha anche a disposizione dei suggerimenti da poter utilizzare. Ogni suggerimento però ti fa perdere dei punti.

### DEFINIZIONE DEI REQUISITI E ANALSI:
- [X] L'applicazione pemette di 
- [X] L'applicazione permette di inserire il nome del giocatore
- [X] L'applicazione permette di fare un salvataggio della partita (salva nel file txt il vincitore della partita)
- [X] L'applicazione permette di terminare il gioco alla fine della quinta manche 
- [X] L'applicazione permette di sommare i valori dei due dadi 
- [X] L'applicazione permette di far vincere il giocatore che ha vinto più manche
- [X] L'applicazione permette di usare un moltiplicatore quando escono due dadi dello stesso numero
- [X] L'applicazione permette di subire una penalità di -5 punti se la somma dei due dadi eqivale a 9 o 23
- [X] L'applicazione permette di vincere subito se escono un dado da 5 e un dado da 6 oppure un dado da 12 e un dado da 18
- [X] L'applicazione permette di verificare se il file txt esiste
- [X] L'applicazione permette la Richiesta di un rematch a fine partita
- [X] L'applicazione permette al giocatore di inserire l'età per verificare che possa giocare in base all'età
- [X] L'applicazione permette al giocatore di scommettere soldi a piacimento
- [X] L'applicazione permette di guadagnare il doppio della puntata se il giocatore vince la partita
- [X] L'applicazione permette di perdere i soldi della puntata se il giocatore non vince la partita
- [X] L'applicazione permette di riavere indietro i soldi della puntata in caso di pareggio

## POST BETA TEST
<details>
    <summary> Raccolta Feedback </summary>


<details>   
    <summary> Feedback di Fabio </summary>

### RACCOLTA DEI FEEDBACK DI FABIO:




**ECCEZIONI**
- ECCEZIONE TRY-CATCH: L'inserimento iniziale dei numeri è corretto, mi piace il "non hai inserito un numero" dopo che si inserisce una lettera! Peccato però che alla richiesta di inserire un nuovo numero, se scrivo nuovamente una lettera mi dà l'errore "System.FormatException",
magari potresti provare ad inserire pure un try/catch alla seconda stringa di risposta. 

**BUG**
- BUG PUNTEGGIO: Ho notato anche che nonostante finisca i punti continui a contarli sotto lo 0 e non si ferma (ad esempio in questo caso se finisco il punteggio a -1, non 0),
credo che mettendo "punteggio <= 0" alla fine questo problema si sistemi

- BUG TENTETIVI: Se ho capito bene vuoi che si fermi il gioco anche dopo 10 tentativi, ho provato 12 volte ma mi fa ancora andare avanti

- BUG SORTEGGIO: Molto particolare anche il fatto che, quando mi chiede "s" per il suggerimento, anche se scrivo "pinguino" me lo dà comunque buono. 
 
Se sistemi queste piccole cose secondo me questo giochino è un bel passatempo!


### PRIORITA'
- [X] BUG PUNTEGGIO
- [X] BUG TENTATIVI
- [X] ECCEZIONE TRY CATCH INSERIMENTO LETTERE AL POSTO DEI NUMERI
- [X] BUG SUGGERIMENTO


</details>

