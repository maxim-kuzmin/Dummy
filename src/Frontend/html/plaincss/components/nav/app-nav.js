customElements.define('app-nav', class extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    this.attachShadow({ mode: 'open' }).append(document.querySelector('#tpl-app-nav').content.cloneNode(true));
  }
});