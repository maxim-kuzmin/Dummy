customElements.define('app-header', class extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    this.attachShadow({ mode: 'open' }).append(document.querySelector('#tpl-app-header').content.cloneNode(true));
  }
});