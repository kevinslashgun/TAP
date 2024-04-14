## Progetti Universitari

Questo repository contiene una serie di progetti sviluppati durante il percorso universitario. I progetti sono principalmente incentrati sulla pratica e sperimentazione di concetti teorici appresi durante i corsi.

### Progetto 1: Frazioni

#### Descrizione
Il primo progetto si concentra sullo sviluppo di una classe `Fraction`, il cui scopo è rappresentare frazioni e implementare operazioni su di esse. L'implementazione segue l'approccio "test first", in cui per ogni funzionalità si definiscono prima i test, e successivamente si procede con l'implementazione.

#### Specifiche
La classe `Fraction` deve soddisfare i seguenti requisiti:
- Proprietà in sola lettura per numeratore e denominatore.
- Costruttore che inizializza l'oggetto con la forma normale della frazione.
- Implementazione degli operatori aritmetici (+, -, *, /) nella sintassi infissa.
- Metodo `ToString` che restituisce la rappresentazione della frazione in forma normale.
- Metodo `Equals` che verifica l'uguaglianza tra frazioni.
- Conversione implicita da intero a frazione.
- Conversione esplicita da frazione a intero, sollevando un'eccezione se il denominatore è diverso da 1.

#### Parte 1: Operator Overloading (Esempio iniziale)
Per cominciare, si definiscono i test per il costruttore, seguendo l'approccio "test first". Si parte con i seguenti casi corretti e scorretti, per garantire una corretta gestione degli input e dei casi limite.

### Progetto 2: Custom-Attribute e Reflection

#### Descrizione
Il secondo progetto si concentra sull'utilizzo di custom-attribute e reflection in C#. L'obiettivo è sviluppare un sistema in cui è possibile annotare metodi con attributi personalizzati e invocarli dinamicamente attraverso reflection.

#### Specifiche
Il progetto si articola in due versioni: una base e una avanzata. Nella versione base, si creano tre progetti in una solution:
- Una console application `Executer`.
- Una libreria di classi `MyAttribute` per definire un custom-attribute `ExecuteMe`.
- Una libreria di classi `MyLibrary` in cui definire classi con metodi annotati con `[ExecuteMe]`.

### Versione Base
1. Definire il custom-attribute `ExecuteMe` che può essere associato a metodi.
2. Creare classi pubbliche in `MyLibrary` con metodi pubblici annotati con `[ExecuteMe]`.
3. Utilizzare reflection in `Executer` per caricare la DLL di `MyLibrary` e invocare dinamicamente i metodi annotati.

### Seconda Release
1. Ottimizzare il riferimento a `MyLibrary` nell'`Executer`.
2. Sperimentare con i valori e i tipi di argomenti per l'annotazione `ExecuteMe`.
3. Gestire errori come l'assenza del costruttore di default e parametri errati nei metodi annotati.

### Possibili Miglioramenti
- Gestire costruttori non di default e parametri opzionali nei metodi annotati.
- Esplorare le interazioni tra custom-attribute, reflection e tipi di parametri.

## Contributi
I contributi sono benvenuti tramite pull request. Per eventuali problemi o suggerimenti, non esitate a creare una nuova issue.
