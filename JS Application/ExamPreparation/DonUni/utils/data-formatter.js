//make data in needed format
export default function (data) {
    return { ...data.data(), id: data.id };
}