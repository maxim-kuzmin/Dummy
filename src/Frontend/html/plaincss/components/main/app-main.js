customElements.define('app-main', class extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    this.attachShadow({ mode: 'open' }).append(document.querySelector('#tpl-app-main').content.cloneNode(true));
  }
});