import * as functions from 'firebase-functions';
// import * as admin from 'firebase-admin';

// admin.initializeApp();

// const db = admin.firestore();

// Start writing Firebase Functions
// https://firebase.google.com/docs/functions/typescript

export const addUrl = functions.https.onRequest((request, response) => {

    // TODO: Http call to IBM Watson followed by saving returned data to firestore
    response.send("Hello World");
});

// export const addUrl = functions.https.onRequest((request, response) => {
//     const url = request.body.url;
//     console.log("url:" + url);

//     db.collection

//     // TODO: Http call to IBM Watson followed by saving returned data to firestore
//     response.send("You sent " + url);
// });

// export const getUser = functions.https.onRequest((request, response) => {
//     db.collection("users").listDocuments()
//         .then(snapshot => response.send(snapshot))
//         .catch(error => {
//             console.log(error);
//             response.status(500).send(error);
//         });
// });
