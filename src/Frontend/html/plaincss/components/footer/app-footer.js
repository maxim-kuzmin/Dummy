customElements.define('app-footer', class extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    this.attachShadow({ mode: 'open' }).append(document.querySelector('#tpl-app-footer').content.cloneNode(true));
  }
});