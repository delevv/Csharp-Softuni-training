const collectionName = 'articles'; //place collection name here
const db = firebase.firestore();

export default {
    post: (data) => db.collection(collectionName).add(data),
    getAll: () => db.collection(collectionName).get(),
    getById: (id) => db.collection(collectionName).doc(id).get(),
    update: (data, id) => db.collection(collectionName).doc(id).update(data),
    delete: (id) => db.collection(collectionName).doc(id).delete()
}