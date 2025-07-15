customElements.define('app-layout', class extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    this.outerHTML = document.querySelector('#tpl-app-layout').innerHTML;
  }
});