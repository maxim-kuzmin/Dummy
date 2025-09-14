<template>
  <header class="app-header">
    <NuxtLink :to="$localePath('index')">{{ $t('component.app-header.link.index.text') }}</NuxtLink>
    <AppLanguage/>
  </header>
</template>
