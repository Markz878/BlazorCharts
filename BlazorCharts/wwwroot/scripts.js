export function getBoundingRectangle(element) {
    const boundingRect = element.getBoundingClientRect();
    return boundingRect;
}