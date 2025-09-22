<script setup lang="ts">
  import { useAppFakePage } from '~/utils/domain/app/pages/fake/app-fake-page.composable'

  definePageMeta({
    middleware: ['app-fake-page-middleware'],
  })

  const { pageKey, click, clickCount } = useAppFakePage()
</script>

<template>
  <div>
    {{ pageKey }}
    <br />
    [<button @click="click">Clicked {{ clickCount }} times</button>]
  </div>
</template>
