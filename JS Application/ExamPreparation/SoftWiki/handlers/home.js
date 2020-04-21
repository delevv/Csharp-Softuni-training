import update from '../utils/update-context.js';
import requests from '../utils/db-requests.js';
import formatData from '../utils/data-formatter.js';

export default {
    get: {
        home(context) {
            update(context)
                .then(function () {
                    if (context.isLoggedIn) {
                        requests.getAll()
                            .then((res) => {
                                if (res != undefined && res != null) {
                                    const articles = res.docs.map(formatData);

                                    context.csharpArt = articles.filter((a) => a.category === 'C#').sort(sortArticles);
                                    context.jsArt = articles.filter((a) => a.category === 'JavaScript').sort(sortArticles);
                                    context.javaArt = articles.filter((a) => a.category === 'Java').sort(sortArticles);
                                    context.pythonArt = articles.filter((a) => a.category === 'Pyton').sort(sortArticles);
                                }
                                this.partial('../templates/home/home.hbs')
                            })
                            .catch((res) => console.log(res))
                    } else {
                        this.partial('../templates/login/login.hbs')
                    }
                });
        }
    }
}

function sortArticles(a, b) {
    return b.title.localeCompare(a.title);
}