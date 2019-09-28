import * as functions from 'firebase-functions';
import * as admin from 'firebase-admin';
// import * as NaturalLanguageUnderstandingV1 from 'ibm-watson/natural-language-understanding/v1';

admin.initializeApp({
    credential: admin.credential.applicationDefault(),
    databaseURL: "https://dev-knowledge-book.firebaseio.com"
});
//admin.initializeApp(functions.config().firebase);

const db = admin.firestore();

// const naturalLanguageUnderstanding = new NaturalLanguageUnderstandingV1({
//     version: '2019-07-12',
//     iam_apikey: 'DQu1eofIByqgFceEocGYtM6STy4TrjZ07RgtBWXehzNP',
//     url: 'https://gateway-syd.watsonplatform.net/natural-language-understanding/api'
// });

// Start writing Firebase Functions
// https://firebase.google.com/docs/functions/typescript

// export const addUrl = functions.https.onRequest((request, response) => {

//     // TODO: Http call to IBM Watson followed by saving returned data to firestore
//     response.send("Hello World");
// });

// export const addUrl = functions.https.onRequest((request, response) => {
//     const analyzeParams = {
//         'url': request.body['url'],
//         'features': {
//             'categories': {},
//             'concepts': {},
//             'keywords': {},
//             'metadata': {}
//         }
//     };

//     naturalLanguageUnderstanding.analyze(analyzeParams)
//         .then(analyzeResult => {
//             console.log(analyzeResult);
//             response.send(analyzeResult);
//         })
//         .catch(error => {
//             console.log(error);
//             response.status(500).send(error);
//         });

// });

export const getUser = functions.https.onRequest((request, response) => {
    db.collection("users").get()
        .then(snapshot => { response.send(snapshot.docs.forEach(document => document.data)); })
        .catch(error => {
            console.log(error);
            response.status(500).send(error);
        });
});
