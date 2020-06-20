let routes = {
    analyze = '/api/analyze/bookmark',
    bookmark = '/api/bookmark/{id}',
    bookmarks = '/api/bookmarks'
};

class Client {
    constructor(baseUrl, apiKey) {
        //baseUrl validation
        if (typeof baseUrl != "string") {
            throw "baseUrl is not a string";
        }
        else if (baseUrl === "") {
            throw "baseUrl is an empty string";
        }

        //apiKey validation
        if (typeof apiKey != "string") {
            throw "apiKey is not a string";
        }
        else if (apiKey === "") {
            throw "apiKey is an empty string";
        }

        this.baseUrl = baseUrl;
        this.apiKey = apiKey;

    }

    Analyze(bookmark) {
        //bookmark validation
        if (typeof bookmark.url != "string") {
            throw "bookmark.url is not a string";
        }
        else if (bookmark.url === "") {
            throw "apiKey is an empty string";
        }

        let request = new XMLHttpRequest();
        request.open("Post", this.baseUrl + routes.analyze);
        //TODO: add event handlers https://developer.mozilla.org/en-US/docs/Web/API/XMLHttpRequest/Using_XMLHttpRequest
        request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
        request.send(JSON.stringify(bookmark));
    }

    Bookmarks() {
        throw 'not implemented';
    }

    Bookmark(id) {
        throw 'not implemented';
    }
}









