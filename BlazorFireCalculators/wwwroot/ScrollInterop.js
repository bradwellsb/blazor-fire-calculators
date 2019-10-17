scrollingElement = (document.scrollingElement || document.body)
window.ScrollToBottom = () => {
    scrollingElement.scrollTop = scrollingElement.scrollHeight;
}