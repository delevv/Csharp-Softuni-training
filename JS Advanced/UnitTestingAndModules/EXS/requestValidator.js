function solve(request) {
    let methods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    let uriPattern = /^[a-z\d\.]*$/;
    let versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    let messagePattern = /^[^<>\\&'"]+$/;

    if (!request['method'] || !methods.includes(request['method'])) {
        throwError('Method');
    }

    if (!request['uri'] || !request['uri'].match(uriPattern)) {
        throwError('URI');
    }

    if (!request['version'] || !versions.includes(request['version']) || request['version'] === '') {
        throwError('Version');
    }

    if ((!request['message'] || !request['message'].match(messagePattern)) && request['message'] !== '') {
        throwError('Message');
    }

    function throwError(type) {
        throw new Error(`Invalid request header: Invalid ${type}`);
    }

    return request;
}